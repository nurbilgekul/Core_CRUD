using System;

namespace Core_CRUD.Models.Entities.Abstract
{ //(access modifier belirtilmemişse default internal)
    public enum Status { Active = 1, Modified = 2, Passive = 3 }
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        //(herhangi bir sınıfın access modifier ile işaretlenmemiş üyesi default olarak private'tır.)
        DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; } //Encapsulation => bir sınıfın private üyesine erişimi public olan üye üzerinden temin ettiğimiz yapdıdır. Bu yapıyı public olan üyenin get; set; methodları üzerinden temin ediyoruz. get dediğimizde private üye üzerindenki değeri elde ederken, dışarıdan gelen değeri filed'ta atarken public üyemizin set; methodunu kullanıyoruz. İşte tüm bu yapıya encapsulation denir.

        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }

    }
}


