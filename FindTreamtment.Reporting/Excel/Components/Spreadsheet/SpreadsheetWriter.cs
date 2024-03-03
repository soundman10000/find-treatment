/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public class SpreadsheetWriter : IDisposable
{
    private readonly SpreadsheetOptions _options;
    private readonly SpreadsheetStateFactory _stateFactory;
    private SpreadsheetState? _state;

    public SpreadsheetWriter(
        SpreadsheetOptions options,
        SpreadsheetStateFactory stateFactory)
    {
        this._options = options;
        this._stateFactory = stateFactory;
    }

    public async Task RenderTableView(WorksheetScaffold scaffold)
    {
        this._state = this._stateFactory.GenerateSpreadsheetState(this._options);

        await WorkSheetWriter.RenderTableView(this._state!.Book, this._state.Sheets, scaffold);

        this._state.Book.Workbook.Save();
        this._state.Doc.Close();

        this._state = null;
        GC.Collect();
    }

    public Task RenderCoverPage()
    {
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        this._state?.Doc.Dispose();
            
        GC.SuppressFinalize(this);
    }
}