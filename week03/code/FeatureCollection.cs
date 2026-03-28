// This file defines the classes needed to read the earthquake JSON data
// from the USGS website. The JSON is structured as a FeatureCollection
// with a list of Features, each having Properties like place and magnitude.

public class FeatureCollection
{
    public Feature[] Features { get; set; }
}

public class Feature
{
    public Properties Properties { get; set; }
}

public class Properties
{
    public string Place { get; set; }
    public double? Mag { get; set; }
}
