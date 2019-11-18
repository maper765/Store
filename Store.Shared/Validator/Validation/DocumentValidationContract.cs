using System.Text.RegularExpressions;

namespace Store.Shared.Validator.Validation
{
    public partial class ValidationContract
    {
        public ValidationContract IsCpf(string number, string property, string message)
        {
            if (!_IsCpf(number))
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsCnpj(string number, string property, string message)
        {
            if (!_IsCnpj(number))
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsPis(string number, string property, string message)
        {
            if (!_IsPis(number))
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsTituloEleitor(string number, string property, string message)
        {
            if (!_IsTituloEleitor(number))
                AddNotification(property, message);

            return this;
        }

        private bool _IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        private bool _IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

        private bool _IsPis(string pis)
        {
            int[] multiplicador = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            if (pis.Trim().Length != 11)
                return false;
            pis = pis.Trim();
            pis = pis.Replace("-", "").Replace(".", "").PadLeft(11, '0');

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(pis[i].ToString()) * multiplicador[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            return pis.EndsWith(resto.ToString());
        }

        private bool _IsTituloEleitor(string titulo)
        {
            int dig1; int dig2; int dig3; int dig4; int dig5; int dig6;
            int dig7; int dig8; int dig9; int dig10; int dig11;
            int dig12; int dv1; int dv2; int qDig;

            if (titulo.Length == 0) //Validação do preenchimento
            {
                return false; //Caso não seja informado o Título
            }
            else
            {
                if (titulo.Length < 12)
                {
                    //Completar 12 dígitos             
                    titulo = "000000000000" + titulo;
                    titulo = titulo.Substring(titulo.Length - 12);
                }
                else if (titulo.Length > 12)
                {
                    return false; //Caso tenha mais que 12 dígitos
                }
            }

            qDig = titulo.Length; //Total de caracteres

            //Gravar posição dos caracteres
            dig1 = int.Parse(titulo.Substring(qDig - 11, 1));
            dig2 = int.Parse(titulo.Substring(qDig - 10, 1));
            dig3 = int.Parse(titulo.Substring(qDig - 9, 1));
            dig4 = int.Parse(titulo.Substring(qDig - 8, 1));
            dig5 = int.Parse(titulo.Substring(qDig - 7, 1));
            dig6 = int.Parse(titulo.Substring(qDig - 6, 1));
            dig7 = int.Parse(titulo.Substring(qDig - 5, 1));
            dig8 = int.Parse(titulo.Substring(qDig - 4, 1));
            dig9 = int.Parse(titulo.Substring(qDig - 3, 1));
            dig10 = int.Parse(titulo.Substring(qDig - 2, 1));
            dig11 = int.Parse(titulo.Substring(qDig - 1, 1));
            dig12 = int.Parse(titulo.Substring(qDig, 1));

            //Cálculo para o primeiro dígito validador
            dv1 = (dig1 * 2) + (dig2 * 3) + (dig3 * 4) + (dig4 * 5) + (dig5 * 6) + (dig6 * 7) + (dig7 * 8) + (dig8 * 9);
            dv1 = dv1 % 11;

            if (dv1 == 10)
            {
                dv1 = 0; //Se o resto for igual a 10, dv1 igual a zero
            }

            //Cálculo para o segundo dígito validador
            dv2 = (dig9 * 7) + (dig10 * 8) + (dv1 * 9);
            dv2 = dv2 % 11;

            if (dv2 == 10)
            {
                dv2 = 0; //Se o resto for igual a 10, dv1 igual a zero
            }

            //Validação dos dígitos validadores, após o cálculo realizado
            if (dig11 == dv1 && dig12 == dv2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
