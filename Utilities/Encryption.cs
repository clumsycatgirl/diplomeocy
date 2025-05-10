using System.Security.Cryptography;
using System.Text;

namespace Diplomeocy;

public static class Encryption {
	public static byte[] GetHash(string inputString) {
		return SHA256.HashData(Encoding.UTF8.GetBytes(inputString));
	}

	public static string GetHashString(string inputString) {
		StringBuilder sb = new StringBuilder();
		foreach (byte b in GetHash(inputString))
			sb.Append(b.ToString("X2"));

		return sb.ToString();
	}

	public static bool CompareWithHashString(string first, string hashed) {
		return hashed == GetHashString(first);
	}
}
