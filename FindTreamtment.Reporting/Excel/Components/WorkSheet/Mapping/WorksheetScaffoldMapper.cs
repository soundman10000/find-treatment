/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public static class WorksheetScaffoldMapper
{
    public static WorksheetOptions ToOptions(
        this WorksheetConfiguration config,
        IEnumerable<WorksheetPartitionScaffold> worksheetPartitionScaffolds) =>
        new(config.SheetName,
            config.Throttle,
            config.DisplayLogo,
            config.LogoEndColumnIndex,
            config.FreezeRowCount,
            config.LogoRightBorderOffset,
            mergeCellsRangeList: config.MergeCellsRangeList,
            customizedCellStyleList: config.CustomizedCellStyleList,
            columnLookUps: worksheetPartitionScaffolds
                .SelectMany(a => a.ColumnLookUps)
                .ToLookup(pair => pair.Key, pair => pair.Value)
                .ToDictionary(g => g.Key, g => g.Max())
        );

    public static WorksheetScaffold MapToScaffold(
        WorksheetConfiguration config) =>
        config
            .Partitions
            .Select(WorkSheetPartitionMapper.ToScaffold)
            .Apply(z => new WorksheetScaffold(config.ToOptions(z), z));
}