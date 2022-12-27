namespace AluCarWepApi.Models
{
    public class Costumer : Entity
    {
        public string Name { get; set; }
        public DateTime DtBirth { get; set; }
        public int CpfCnpj{ get; set; }
        public int CnhNumber { get; set; }
        public int CellPhone { get; set; }
        public int Cep { get; set; }

        public Costumer(string name, DateTime dtBirth, int cpfCnpj, int cnhNumber, int cellPhone, int cep)
        {
            Name = name;
            DtBirth = dtBirth;
            CpfCnpj = cpfCnpj;
            CnhNumber = cnhNumber;
            CellPhone = cellPhone;
            Cep = cep;
        }
    }
}
