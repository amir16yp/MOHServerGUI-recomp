using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace MOHServer
{
    internal class MohzPatcher
    {
        private readonly frmMain mainForm;
        private const string EXPECTED_MD5 = "27AC7D9C0AB6811814F4E6AF864F2D21";
        private const string PATCHED_MD5 = "B40944552CF36F55AA2425A2421C2B17";
        private const long IMAGE_BASE = 0x00400000;

        private class PatchOperation
        {
            public long Address { get; set; }
            public byte Original { get; set; }
            public byte New { get; set; }
        }

        public MohzPatcher(frmMain form)
        {
            mainForm = form;
        }

        public bool IsMohzPatched()
        {
            string mohzPath = Path.Combine(mainForm.ServerPath, "mohz.exe");
            try
            {
                using (var md5 = MD5.Create())
                using (var stream = File.OpenRead(mohzPath))
                {
                    var hash = md5.ComputeHash(stream);
                    var computedMd5 = BitConverter.ToString(hash).Replace("-", "").ToUpperInvariant();
                    return computedMd5 == PATCHED_MD5;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool VerifyMd5AndBackup(string filePath, string backupPath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    mainForm.WriteStreamInfo("mohz.exe does not exist, please make sure you've downloaded the full MOHH package.",
                        Color.Red, FontStyle.Bold);
                    return false;
                }

                using (var md5 = MD5.Create())
                using (var stream = File.OpenRead(filePath))
                {
                    var hash = md5.ComputeHash(stream);
                    var computedMd5 = BitConverter.ToString(hash).Replace("-", "").ToUpperInvariant();

                    if (computedMd5 == EXPECTED_MD5 || computedMd5 == PATCHED_MD5)
                    {
                        File.Copy(filePath, backupPath, true);
                        mainForm.WriteStreamInfo("SYSTEM: Backup created successfully.",
                            Color.DarkGreen, FontStyle.Regular);
                        return true;
                    }

                    mainForm.WriteStreamInfo("ERROR: MD5 mismatch. No backup created.",
                        Color.Red, FontStyle.Bold);
                    return false;
                }
            }
            catch (Exception e)
            {
                mainForm.WriteStreamInfo($"ERROR: {e.Message}", Color.Red, FontStyle.Bold);
                return false;
            }
        }

        private bool ApplyPatches(string inputFile, string outputFile, List<PatchOperation> patches)
        {
            try
            {
                var binaryData = File.ReadAllBytes(inputFile);
                bool success = true;

                foreach (var patch in patches)
                {
                    var adjustedAddress = patch.Address - IMAGE_BASE;

                    if (adjustedAddress < 0 || adjustedAddress >= binaryData.Length)
                    {
                        mainForm.WriteStreamInfo($"ERROR: Address {patch.Address:X} is out of range. File size is {binaryData.Length} bytes.",
                            Color.Red, FontStyle.Bold);
                        success = false;
                        continue;
                    }

                    if (binaryData[adjustedAddress] == patch.Original)
                    {
                        binaryData[adjustedAddress] = patch.New;
                        mainForm.WriteStreamInfo($"SYSTEM: Successfully patched {patch.Original:X2} to {patch.New:X2} at {patch.Address:X}.",
                            Color.DarkGreen, FontStyle.Regular);
                    }
                    else
                    {
                        mainForm.WriteStreamInfo($"ERROR: The byte at {patch.Address:X} does not match the expected opcode {patch.Original:X2}. Current byte: {binaryData[adjustedAddress]:X2}.",
                            Color.Red, FontStyle.Bold);
                        success = false;
                    }
                }

                if (success)
                {
                    File.WriteAllBytes(outputFile, binaryData);
                    mainForm.WriteStreamInfo($"SYSTEM: Patched file saved as {outputFile}.",
                        Color.DarkGreen, FontStyle.Regular);
                }

                return success;
            }
            catch (Exception e)
            {
                mainForm.WriteStreamInfo($"ERROR: {e.Message}", Color.Red, FontStyle.Bold);
                return false;
            }
        }

        public void PatchMohzExecutable()
        {
            if (IsMohzPatched())
            {
                mainForm.WriteStreamInfo("SYSTEM: mohz.exe is already patched.", Color.DarkGreen, FontStyle.Regular);
                return;
            }

            string mohzPath = Path.Combine(mainForm.ServerPath, "mohz.exe");
            string backupPath = Path.Combine(mainForm.ServerPath, "mohz.bak.exe");
            string patchedPath = Path.Combine(mainForm.ServerPath, "mohz_patched.exe");

            if (VerifyMd5AndBackup(mohzPath, backupPath))
            {
                var patches = new List<PatchOperation>
                {
                    new PatchOperation { Address = 0x0060AF90, Original = 0x74, New = 0x75 }, // Illegal character in server name patch
                    new PatchOperation { Address = 0x006ea181, Original = 0x74, New = 0x75} // Dont use SSL patch
                };

                if (ApplyPatches(mohzPath, patchedPath, patches))
                {
                    try
                    {
                        File.Copy(patchedPath, mohzPath, true);
                        File.Delete(patchedPath);
                        mainForm.WriteStreamInfo("SYSTEM: Original file replaced with patched version.",
                            Color.DarkGreen, FontStyle.Regular);
                        mainForm.UpdatePatchStatus();
                    }
                    catch (Exception e)
                    {
                        mainForm.WriteStreamInfo($"ERROR: Failed to replace original file: {e.Message}",
                            Color.Red, FontStyle.Bold);
                    }
                }
            }
        }
    }
}
