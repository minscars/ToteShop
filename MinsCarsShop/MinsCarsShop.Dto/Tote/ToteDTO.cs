﻿using MinsCarsShop.Dto.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinsCarsShop.Dto.Tote
{
	public class ToteDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public string CategoryName { get; set; }
		public int Price { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }
	}
}
