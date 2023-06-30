Constructing a car 
============

## Engine and Fuel Tank

You have to construct a car. Step by Step. Kata by Kata.
First you have to implement the engine and the fuel tank.

The default fuel level of a car is 20 liters.
The maximum size of the tank is 60 liters.
Of course every car's life begins with an engine not running. ;-)

Every call of a method from the car correlates to 1 second.

The fuel consumption in running idle is 0.0003 liter/second.
For convenience the start of the engine consumes nothing and we don't care, if the engine is warm or cold.

The fuel tank is on reserve, if the level is under 5 liters.
The fuel tank display shows the level as rounded for 2 decimal places.
Internally an accuracy up to 10 decimal places should be more than enough.
In difference to most real cars, the fuel tank display is always showing its information, also when the the engine is not running.

And consider the locigal things about fuel and engine... ;-)

## Driving

If the car is free-wheeling (no pedal is used), it slows down the car by 1 km/h by air resistance and rolling resistance.
Braking is BY a speed. Accelerating is TO a speed. (Remember: Every call of a method from the car correlates to 1 second.)
For every car the default acceleration is at most 10 km/h per second.
In a new further constructor of the car it should be possible to set a higher acceleration. The value has always to be in a range from 5 to 20. Correct if under minimum or above maximum.
Every car brakes at most 10 km/h per second. (Very bad brakes, I know... This car would braking bad. :D)

The maximum speed of a car is 250 km/h and of course it cannot have a negative speed.

The consumption for a driving car is be taken from these ranges:
1 - 60 km/h -> 0.0020 liter/second
61 - 100 km/h -> 0.0014 liter/second
101 - 140 km/h -> 0.0020 liter/second
141 - 200 km/h -> 0.0025 liter/second
201 - 250 km/h -> 0.0030 liter/second

(When the car brakes or freewheels with getting slower, there is no fuel consumption as in modern cars, when the car "powers" the engine.)

For convenience the accelerations and brakings are always linear and consumption is only for the speed at the end of every second. No considering on higher consumption while accelerating within a second.

## On-Board Computer

The On-Board Computer should display the following informations:

* trip real time
* trip driving time
* total real time
* total driving time
* trip driven distance
* total driven distance
* actual speed (additional to the drivingInformationDisplay)
* trip average speed
* total average speed
* actual consumption by time (from the last second/method)
* actual consumption by distance (from the last second/method)
* trip average consumption by time
* total average consumption by time
* trip average consumption by distance
* total average consumption by distance
* estimated range with actual fuel level

"trip" means since enginestart. The "total"-counter keep their values beyond enginestarts.

The On-Board Computer should be resetable for the "trip" and for "total". 

The speed-average-values are calculated by driving time (km/h) and should be rounded for 1 decimal place.The actual-consumption-by-time is calculated by second and should be rounded for 5 decimal places. 

The actual-consumption-by-distance is calculated in liter/100 km and should be rounded for 1 decimal place. If the car does not drive, it should return NaN. 

The consumption-average-by-time-values are calculated by real time (liter/second) and should be rounded for 5 decimal places.

The consumption-average-by-distance-values are calculated in liter/100 km and should be rounded for 1 decimal place.

The driving-distance-values are calculated in km and should have at max 2 decimal places.

The estimated-range should be calculated in km and base on the consumption of the last 100 seconds. When the car is built, it should be assumed that the consumption was 4.8 Liter for the last 100 seconds.

> **Hint:**
> 
> Also the values actual-consumption-by-distance and > > consumption-average-by-distance are calculated every second! (They are NOT calculated e.g. every 1 km or 10km. This would be much more realistic but would also make this kata much more complicated!)

> **Remember:**
>
> Every call of a method (except Refuel :D) from the car correlates to 1 second. Methods from the On-Board Computer correlates to 0 seconds.

> **Hint:**
>
> The methods "EngineStart" and "EngineStop" of the DrivingProcessor do NOT start the engine, but give the event into the DrivingProcessor, that the engine has started or stopped.