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
    'icao24': '7800ed', 
    'call_sign': 'CES5124 ', 
    'origin_country': 'China', 
    'last_position_update': 1507203250, 
    'last_contact': 1507203250, 
    'longitude': 116.8199, 
    'latitude': 40.2763, 
    'baro_altitude': 3459.48, 
    'on_ground': False, 
    'velocity': 181.88, 
    'heading': 84.64, 
    'vertical_rate': 11.7, 
    'geo_altitude': None, 
    'squawk': 3566.16, 
    '5632', 
    'spi': False, 
    'position_source': 0
    ],...
  ],
  'time': 1507203250,
  ...
}
```

## Resources

* [API documentation](https://opensky-network.org/apidoc)
* [OpenSky Forum](https://opensky-network.org/forum)
