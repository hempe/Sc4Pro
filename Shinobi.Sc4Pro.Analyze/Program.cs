if (args.Length > 0 && args[0].EndsWith(".log"))
{
    var output = Path.ChangeExtension(args[0], ".json");
    await Shinobi.Sc4Pro.Analyze.BtSnoopParser.ParseAsync(args[0], output);
}
else
{
    await Shinobi.Sc4Pro.Analyze.Analyzer.RunAsync();
}
