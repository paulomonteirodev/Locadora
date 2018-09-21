using Paulo.Core.Services;

namespace Paulo.Impl.Services
{
    public class CpfService : ICpfService
    {
        public bool Validade(string cpf)
        {
            if (cpf.Length != 11)
                return false;

            var allEqualNumbers = true;
            for (int i = 1; i < 11 && allEqualNumbers; i++)
                if (cpf[i] != cpf[0])
                    allEqualNumbers = false;

            if (allEqualNumbers || cpf == "12345678909")
                return false;

            int[] numbers = new int[11];
            for (int i = 0; i < 11; i++)
                numbers[i] = int.Parse(cpf[i].ToString());


            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += (10 - i) * numbers[i];

            int result = sum % 11;
            if (result == 1 || result == 0)
            {
                if (numbers[9] != 0)
                    return false;
            }
            else if (numbers[9] != 11 - result)
                return false;

            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += (11 - i) * numbers[i];

            result = sum % 11;

            if (result == 1 || result == 0)
            {
                if (numbers[10] != 0)
                    return false;

            }
            else
                if (numbers[10] != 11 - result)
                return false;

            return true;
        }
    }
}
