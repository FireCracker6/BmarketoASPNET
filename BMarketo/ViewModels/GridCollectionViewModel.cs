﻿namespace BMarketo.ViewModels;

public class GridCollectionViewModel
{
    public string Title { get; set; } = "";
   
    public IEnumerable<string> Categories { get; set; } = null!;
    public IEnumerable<GridCollectionItemViewModel> GridItems { get; set; } = null!;
    public IEnumerable<GridCollectionSmallCardsItemViewModel> GridItemsSmall { get; set; } = null!;

    public bool LoadMore { get; set; } = false;
}
