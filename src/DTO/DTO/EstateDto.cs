﻿using System.Collections.Generic;

// tbd this is the model for Estate that I want in the future, that will replace EstateTempDto
namespace DTO.DTO
{
    public class EstateDto
    {
			public int Id { get; set; }
			public string Title { get; set; }

			// Total Surace (including garden, etc) in square meters
			public int Area { get; set; }
			public int Price { get; set; }
			public int UsableSurface { get; set; }
			public int TotalSurface { get; set; }
			public int LocationId { get; set; }
			public List<ImageDto> Images { get; set; }
    }
}