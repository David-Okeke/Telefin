using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EarlyMan.Models.ViewModels
{
    public class HomepageItems
    {
        // Do I plug in the services I have created here?
        public IPrintRepository printRepository { get; set; }

        public IPromotionRepository promotionRepository { get; set; }
    }
}