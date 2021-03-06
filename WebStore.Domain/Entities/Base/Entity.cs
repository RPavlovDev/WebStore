using System.ComponentModel.DataAnnotations;
using WebStore.Domain.Entities.Interfaces;

namespace WebStore.Domain.Entities.Base
{
    public abstract class Entity : IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
