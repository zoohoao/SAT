using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using SAT.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT.Core.Common
{
    internal class Register
    {
        //生成私钥，公钥
        public static RsaBase64Key RsaKeyPairGenerator()
        {
            RsaBase64Key key = new RsaBase64Key();

            //RSA密钥对的构造器
            RsaKeyPairGenerator keyGenerator = new RsaKeyPairGenerator();

            //RSA密钥构造器的参数
            RsaKeyGenerationParameters param = new RsaKeyGenerationParameters(
                Org.BouncyCastle.Math.BigInteger.ValueOf(3),
                new Org.BouncyCastle.Security.SecureRandom(),
                2048,   //密钥长度
                25);
            //用参数初始化密钥构造器
            keyGenerator.Init(param);
            //产生密钥对
            AsymmetricCipherKeyPair keyPair = keyGenerator.GenerateKeyPair();
            //获取公钥和密钥
            AsymmetricKeyParameter publicKey = keyPair.Public;
            AsymmetricKeyParameter privateKey = keyPair.Private;

            key.PrivateKey = ConvertPrivateKeyToBase64String(privateKey);
            key.PublicKey = ConvertPublicKeyToBase64String(publicKey);

            return key;
        }

        private static string ConvertPublicKeyToBase64String(AsymmetricKeyParameter publicKey)
        {
            SubjectPublicKeyInfo publicKeyInfo = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(publicKey);
            Asn1Object aobject = publicKeyInfo.ToAsn1Object();
            byte[] pubInfoByte = aobject.GetEncoded();

            string publicKeyBase64String = Convert.ToBase64String(pubInfoByte);
            return publicKeyBase64String;
        }

        private static string ConvertPrivateKeyToBase64String(AsymmetricKeyParameter privateKey)
        {
            PrivateKeyInfo privateKeyInfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(privateKey);
            Asn1Object aobject = privateKeyInfo.ToAsn1Object();
            byte[] priInfoByte = aobject.GetEncoded();

            string privateKeyBase64String = Convert.ToBase64String(priInfoByte);
            return privateKeyBase64String;
        }

        private static AsymmetricKeyParameter ConvertBase64StringToPublicKey(string publicKeyBase64String)
        {
            byte[] publicKeyBytes = Convert.FromBase64String(publicKeyBase64String);

            Asn1Object aobject = Asn1Object.FromByteArray(publicKeyBytes);
            SubjectPublicKeyInfo pubInfo = SubjectPublicKeyInfo.GetInstance(aobject);
            AsymmetricKeyParameter publicKey = (RsaKeyParameters)PublicKeyFactory.CreateKey(pubInfo);

            return publicKey;
        }

        private static AsymmetricKeyParameter ConvertBase64StringToPrivateKey(string privateKeyBase64String)
        {
            byte[] privateKeyBytes = Convert.FromBase64String(privateKeyBase64String);

            Asn1Object aobj = Asn1Object.FromByteArray(privateKeyBytes);
            AsymmetricKeyParameter privateKey = PrivateKeyFactory.CreateKey(aobj.GetEncoded());

            return privateKey;
        }

        public static string EncryptionByPrivateKey(string context, string privateKeyBase64String)
        {
            AsymmetricKeyParameter encryptionKey = ConvertBase64StringToPrivateKey(privateKeyBase64String);

            return Encryption(context, encryptionKey);
        }

        public static string EncryptionByPublicKey(string context, string publicKeyBase64String)
        {
            AsymmetricKeyParameter encryptionKey = ConvertBase64StringToPublicKey(publicKeyBase64String);

            return Encryption(context, encryptionKey);
        }

        private static string Encryption(string context, AsymmetricKeyParameter encryptionKey)
        {
            byte[] contextBytes = Encoding.UTF8.GetBytes(context);

            //非对称加密算法，加密用
            IAsymmetricBlockCipher engine = new RsaEngine();
            //私钥加密
            engine.Init(true, encryptionKey);
            var encryption = engine.ProcessBlock(contextBytes, 0, contextBytes.Length);
            string encryptionString = Convert.ToBase64String(encryption);

            return encryptionString;
        }

        public static string DecryptByPrivateKey(string encryptionString, string privateKeyBase64String)
        {
            AsymmetricKeyParameter decryptKey = ConvertBase64StringToPrivateKey(privateKeyBase64String);

            return Decrypt(encryptionString, decryptKey);
        }

        public static string DecryptByPublicKey(string encryptionString, string publicKeyBase64String)
        {
            AsymmetricKeyParameter decryptKey = ConvertBase64StringToPublicKey(publicKeyBase64String);

            return Decrypt(encryptionString, decryptKey);
        }

        private static string Decrypt(string encryptionContext, AsymmetricKeyParameter decryptKey)
        {
            byte[] encryptionBytes = Convert.FromBase64String(encryptionContext);

            //非对称加密算法，解密用
            IAsymmetricBlockCipher engine = new RsaEngine();
            //公钥加密
            engine.Init(false, decryptKey);
            var decrypt = engine.ProcessBlock(encryptionBytes, 0, encryptionBytes.Length);
            string context = Encoding.UTF8.GetString(decrypt);

            return context;
        }
    }
}