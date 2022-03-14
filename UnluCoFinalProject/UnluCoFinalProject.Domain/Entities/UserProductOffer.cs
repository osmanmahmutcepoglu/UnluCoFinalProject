using System;

namespace UnluCoFinalProject.Domain.Entities
{
    public class UserProductOffer : BaseEntity
    {
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int OfferPrice { get; set; }
        public bool OfferAccept { get; set; }
        public DateTime OfferDate { get; set; }
        public string ProductUserId { get; set; }
        public virtual Product Product { get; set; }
    }
}
