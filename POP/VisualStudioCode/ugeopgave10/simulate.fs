module DroneTraffic

///<summary>Drone is a class representation of a drone, that is set to start in 1 point of a 2D-space and end in another point of the 2D-space. The drone has a constant speed that never changes.</summmary>
///<param name = "x">The x coordinate for the drone's starting point.</summary>
///<param name = "y">The y coordinate for the drone's starting point.</summary>
///<param name = "x1">The x coordinate for the drone's endpoint.</summary>
///<param name = "y1">The y coordinate for the drone's endpoint.</summary>
///<param name = "speed">The speed that the drone is gonna fly with. Speed is assumed only to able to be positive, so if a negative input is put into speed then the instance of the class Drone will use the absolute value of the input instead.</summary>
///<returns>An instance of the class Drone.</returns>
type Drone(x:float, y:float, x1:float, y1:float, speed:float) =
    let mutable dronePosition = (x, y) //The drone's current position.
    let endDestination = (x1, y1) //The drone's endposition.
    let travelDistance = sqrt(((x1-x)**2.0) + ((y1-y)**2.0)) //The distance that the drone has to travel in order to reach it's end destination.
    let directionVector = ((x1-x)/travelDistance, (y1-y)/travelDistance) //The direction, that the drone is going in the 2D-space.
    let mutable currentSpeedString = abs(speed) |> string //The speed of the drone but as a string.
    let mutable currentSpeed = (abs(speed) * (fst directionVector), abs(speed) * (snd directionVector)) //The velocity of the drone.
    let mutable active = true //The state of the drone/If the drone is still flying.
    let mutable collided = false //Whether or not the drone has collided with any other drone.
    member this.CurrentSpeed =
        currentSpeed
    member this.Position : (float * float) = //A property the gives the drone's current position.
        dronePosition
    member this.Speed () : string = //A property that gives the speed as a string with the given unit defintion.
        currentSpeedString + "m/min" 
    member this.Destination () : (float * float) = //A property the gives the endDestination.
        endDestination
    ///<summary>Moves the drone towards its end destination. If the drones reaches its end destination, then it changes the drone's state.</summmary>
    member this.Fly () : unit =
        if this.IsActive = false then //checks whether or not the drone is active.
            ()
        else
            if sqrt((x1 - (fst dronePosition))**2.0 + (y1 - (snd dronePosition))**2.0) <= abs(speed) then //checks if the drone will reach its end destination within the next minute.
                dronePosition <- endDestination //sets the drone's position to be the end destination, since it should not go further than that.
                this.IsActive <- false // changes the state of the drone, since it has reached the end destination
            else
                dronePosition <- ((fst dronePosition) + (fst currentSpeed), (snd dronePosition) + (snd currentSpeed)) // Moves the drone towards its end destination
    member this.IsFinished () : bool = // checks if the drone has reached its end destination
        dronePosition = endDestination
    ///<summary>Tells whether or not the drone is active or changes the drone's state.</summmary>
    ///<param name = "a">The parameter used to change the active state to either false or true, depeneding on what is desired.</summary>
    ///<returns>The state of the drone.</returns>
    member this.IsActive 
        with get () = active //Gives the state.
        and set (a) = active <- a //Sets the state.
    ///<summary>Tells whether or not the drone has collided with any other drone yet</summmary>
    ///<param name = "b">The parameter used to change the collided state to either false or true, depending on what is desired.</summary>
    ///<returns>A boolean depending on the drone's collided state.</returns>
    member this.HasCollided 
        with get () = collided //Gives the state.
        and set (b) = collided <- b //Sets the state.
    member this.TravelDistance () : float = //Gives the distance the drone has to travel.
        travelDistance

///<summary>Airspace is a class representation of a list of drones.</summmary>
///<param name = "droneList">Is a list of drones.</summary>
///<returns>An instance of the class Airspace.</returns>
type Airspace(droneList:Drone list) =
    let mutable drones = droneList //The list of drones.
    member this.Drones = //Gives the list of drones.
        drones
    ///<summary>A representation of the drone list but as integers.</summmary>
    ///<returns>An integer list that represents the current drones in the Airspace instance.</returns>
    member this.CurrentDrones () : int list = 
        List.init drones.Length (id) //Creates a new list with the same length as the drone list, but now containing integers from 0 and up.
    ///<summary>The distance between two given drones.</summmary>
    ///<param name = "drone1">The first drone.</summary>
    ///<param name = "drone2">The second drone.</summary>
    ///<returns>The distance between drone1 and drone2.</returns>
    member this.DroneDist (drone1:Drone, drone2:Drone) : float = 
        ((fst drone2.Position - fst drone1.Position)**2.0 + (snd drone2.Position - snd drone1.Position)**2.0) |> sqrt //The distance between the two drones.
    ///<summary>Uses Fly on all drones in the list.</summmary>
    member this.FlyDrones () : unit =
        for i=0 to drones.Length - 1 do 
            drones.[i].Fly ()
    ///<summary>Adds a new drone to the list of drones in the given Airspace.</summmary>
    ///<param name = "d">The drone to be added to the list.</summary>
    member this.AddDrone (d:Drone) : unit =
        drones <- drones @ [d] //The new drone appended into the list.
    ///<summary>Predicts which if the drones in the list that will collide after a given amount of time.</summmary>
    ///<param name = "minutes">The amount of time the drones is gonna fly as an integer.</summary>
    ///<returns>A list of integer tuples, that represent which of the drones that will have collided in the given amount of time. If the case is that more than two drones will collide simultainously for example 0, 1 and 2, then it will return [(0,1),(0,2),(1,2)].</returns>
    member this.WillCollide (minutes:int) : (int * int) list =
        let mutable result = [] //The list of tupled integers, that will be returned in the end.
        for i=1 to minutes do //A for-loop that runs from 1 to the amount of given minutes.
            this.FlyDrones () //The for-loop uses FlyDrones on the list every minute
            for n=0 to drones.Length - 2 do //A nested for-loop that runs through the list from start till the second last element in the list.
                for m=n+1 to drones.Length - 1 do //A nested for-loop in a nested for-loop, that runs through the list from n to the last element in the list.
                    if (drones.[n].IsActive) && (drones.[m].IsActive) && this.DroneDist (drones.[n], drones.[m]) < 5.0 then //Checks if the compared drones is active and then what their distance to eachother is.
                        result <- result @ [(n, m)] //Appends the collided drones as a tuple of the two respectively representative integers to the result list.
                        drones.[n].HasCollided <- true; drones.[m].HasCollided <- true //Changes the two collided drones collision state to true.
                    else
                        () 
                if drones.[n].HasCollided then drones.[n].IsActive <- false else () //Changes the active state of the n drone if it has collided.
            if drones.[drones.Length - 1].HasCollided then drones.[drones.Length - 1].IsActive <- false else () //Changes the active state of the last drone if it has collided.
        result //Returning the result


