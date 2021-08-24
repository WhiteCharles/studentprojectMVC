﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace studentprojectMVC
{
    public partial class ShoppingCartItems
    {
        public int ShoppingCartItemId { get; set; }
        public int? RecordId { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
