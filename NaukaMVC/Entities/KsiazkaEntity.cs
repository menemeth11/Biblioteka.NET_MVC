using System.ComponentModel.DataAnnotations;

namespace NaukaMVC.Entities
{
    public class KsiazkaEntity
    {
        //[Key] //string? zezwala na null -> zrobione w NaukaMVC
        public int Id { get; set; }
        public string Tytul { get; set; } = default!; //nie zezwala na null/ nie jest domyslna
        public string Autor { get; set; } = default!;
        public string Opis { get; set; } = default!;
        public int? Strony { get; set; }
        public DateTime RokWydania { get; set; }

    }
}
