using Microsoft.AspNetCore.Identity;

namespace Business.Configurations;

public class CustomIdentityValidator : IdentityErrorDescriber
{
	//! Türkçeleştirme işlemleri 
	public override IdentityError PasswordTooShort(int length)
	{
		return new IdentityError() { Code = "PasswordTooShort",Description=$"Parola en az {length} karakter olmalıdır." };
	}

}
