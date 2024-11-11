using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

public class FileHasher
{
    /// <summary>
    /// Calcula el hash SHA-256 de un archivo dado.
    /// </summary>
    /// <param name="filePath">Ruta completa del archivo.</param>
    /// <returns>Hash SHA-256 como una cadena hexadecimal.</returns>
    public static string GetFileHashSHA256(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentException("La ruta del archivo no puede estar vacía.", nameof(filePath));

        if (!File.Exists(filePath))
            throw new FileNotFoundException("El archivo especificado no existe.", filePath);

        try
        {
            using (FileStream stream = File.OpenRead(filePath))
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(stream);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al calcular el hash: {ex.Message}");
            return string.Empty;
        }
    }
}
