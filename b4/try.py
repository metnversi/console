import rsa
from base64 import b64encode

# Load the public key
public_key_data = '''-----BEGIN PUBLIC KEY-----
MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCsn//YAXtvUmzfcdUSVc80NgMM
NFIc/EyzOnLKcUM6Xm+up8K7AymL6TpOpgdtxDB30GlQjK7RNwJLgNSzT7d7OXJq
382cX0V6aYXA9oeZ93bsdpiDNOMNu1ezlWZNJBS2sJoUnQl7mTGJN2b44wUcqh98
F3wPTUp/+rydh3oBkQIDAQAB
-----END PUBLIC KEY-----'''
pubkey = rsa.PublicKey.load_pkcs1_openssl_pem(public_key_data.encode())

# Encrypt the data
message = 'admin123'.encode()
encrypted_message = rsa.encrypt(message, pubkey)

# Print the encrypted message in base64 so it can be easily copied and stored
print(b64encode(encrypted_message).decode())