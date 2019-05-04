# The  OpenSky Network API

This repository contains API client implementations for the OpenSky API REST in C#.

### Installation

WIP

### Usage

```c#
 OpenSkyApi api = new OpenSkyApi();

 States result = api.GetStates();
 
 Console.WriteLine(result);
```

will output something like this:

```
{
  'states': [
    StateVector(dict_values(['c04049', '', 'Canada', 1507203246, 1507203249, -81.126, 37.774, 10980.42, False, 245.93, 186.49, 0.33, None, 10972.8, None, False, 0])),
    StateVector(dict_values(['4240eb', 'UTA716  ', 'United Kingdom', 1507202967, 1507202981, 37.4429, 55.6265, 609.6, True, 92.52, 281.87, -3.25, None, None, '4325', False, 0])),
    StateVector(dict_values(['aa8c39', 'UAL534  ', 'United States', 1507203250, 1507203250, -118.0869, 33.8656, 1760.22, False, 111.31, 343.07, -5.2, None, 1752.6, '2643', False, 0])),
    StateVector(dict_values(['7800ed', 'CES5124 ', 'China', 1507203250, 1507203250, 116.8199, 40.2763, 3459.48, False, 181.88, 84.64, 11.7, None, 3566.16, '5632', False, 0])),...
  ],
  'time': 1507203250
}
```

## Resources

* [API documentation](https://opensky-network.org/apidoc)
* [OpenSky Forum](https://opensky-network.org/forum)
