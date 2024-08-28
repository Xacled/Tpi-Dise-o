namespace Reciplas.Shared;

public class CListado<TItem> : Radzen.Blazor.RadzenDataGrid<TItem>
{
    public CListado()
    {
       
        AllowFiltering = true;
        AllowSorting = true;
        AllowPaging = true;
        AllowVirtualization = true;
        ColumnWidth = "300px";
        EmptyText = "No se han encontrado registros.";
        FilterCaseSensitivity = Radzen.FilterCaseSensitivity.CaseInsensitive;
        FilterMode = Radzen.FilterMode.Simple;
        FilterPopupRenderMode = Radzen.PopupRenderMode.OnDemand;
        PageSize = 15;
        PagerAlwaysVisible = true;
        PagerHorizontalAlign = Radzen.HorizontalAlign.Center;
        Responsive = true;
        SelectionMode = Radzen.DataGridSelectionMode.Single;
        ShowPagingSummary = true;
        GridLines = Radzen.DataGridGridLines.Horizontal;
        GroupPanelText = "Arrastre una columna aqui para agrupar por ella.";
        ColumnsShowingText = " columnas mostradas";
        AllColumnsText = "Todos";
        PageSizeText = "registros por pagina";
        PagingSummaryFormat = "Pagina {0} de {1} ({2} registros)";
    }
}