open DroneTraffic

    type WhiteBoxTest() =
        let frthTestDrone = Drone (0.0, 0.0, 0.0, 0.0, 10.0)
        //let testAirspace = Airspace [testDrone; sndTestDrone; thrdTestDrone]
        member this.WbtFly =
            let flyDrone = Drone (0.0, 0.0, 10.0, 10.0, 5.0)
            let sndFlyDrone = Drone (0.0, 0.0, -10.0, -10.0, 5.0)
            let thrdFlyDrone = Drone (0.0, 0.0, 10.0, 10.0, -5.0)
            printfn "This test will use the drones:\n flyDrone = Drone (0.0, 0.0, 10.0, 10.0, 5.0)\n sndFlyDrone = Drone (0.0, 0.0, -10.0, -10.0, 5.0)\n thrdFlyDrone = Drone (0.0, 0.0, 10.0, 10.0, -5.0)\n"
            printfn "flyDrone should move \"%A\" along the x-axis and \"%A\" along the y-axis" (fst (flyDrone.CurrentSpeed)) (snd (flyDrone.CurrentSpeed))
            flyDrone.Fly ()
            printfn "This is flyDrone's position after 1 minute: %A" flyDrone.Position
            printfn "The drone should stay in position if IsActive is changed to false"
            flyDrone.IsActive <- false
            flyDrone.Fly ()
            printfn "This is flyDrone's position after another minute when IsActive is false: %A" flyDrone.Position
            printfn "After 4 minutes while IsActive is true, then the drone should have reached its end destination"
            flyDrone.IsActive <- true
            flyDrone.Fly ();   flyDrone.Fly ();   flyDrone.Fly ()
            printfn "This is flyDrone's position after 4 minutes while IsActive is true: %A" flyDrone.Position
            
            printfn "\nsndFlyDrone should move \"%A\" along the x-axis and \"%A\" along the y-axis" (fst (sndFlyDrone.CurrentSpeed)) (snd (sndFlyDrone.CurrentSpeed))
            sndFlyDrone.Fly ()
            printfn "This is sndFlyDrone's position after 1 minute: %A" sndFlyDrone.Position
            printfn "The drone should stay in position if IsActive is changed to false"
            sndFlyDrone.IsActive <- false
            sndFlyDrone.Fly ()
            printfn "This is sndFlyDrone's position after another minute when IsActive is false: %A" sndFlyDrone.Position
            printfn "After 4 minutes while IsActive is true, then the drone should have reached its end destination"
            sndFlyDrone.IsActive <- true
            sndFlyDrone.Fly ();   sndFlyDrone.Fly ();   sndFlyDrone.Fly ()
            printfn "This is sndFlyDrone's position after 4 minutes while IsActive is true: %A" sndFlyDrone.Position

            printfn "\nthrdFlyDrone should move \"%A\" along the x-axis and \"%A\" along the y-axis" (fst (thrdFlyDrone.CurrentSpeed)) (snd (thrdFlyDrone.CurrentSpeed))
            thrdFlyDrone.Fly ()
            printfn "This is thrdFlyDrone's position after 1 minute: %A" thrdFlyDrone.Position
            printfn "The drone should stay in position if IsActive is changed to false"
            thrdFlyDrone.IsActive <- false
            thrdFlyDrone.Fly ()
            printfn "This is thrdFlyDrone's position after another minute when IsActive is false: %A" thrdFlyDrone.Position
            printfn "After 4 minutes while IsActive is true, then the drone should have reached its end destination"
            thrdFlyDrone.IsActive <- true
            thrdFlyDrone.Fly ();   thrdFlyDrone.Fly ();   thrdFlyDrone.Fly ()
            printfn "This is thrdFlyDrone's position after 4 minutes while IsActive is true: %A" thrdFlyDrone.Position
        member this.WbtIsActive =
            let isActiveDrone = Drone (0.0, 0.0, 0.0, 0.0, 0.0)
            printfn "This test will use the drone:\n isActiveDrone = Drone (0.0, 0.0, 0.0, 0.0, 0.0)\n"
            printfn "IsActive should return true at start and it returns: %A" isActiveDrone.IsActive
            isActiveDrone.IsActive <- false
            printfn "IsActive should return false, when it is changed to false and it returns: %A" isActiveDrone.IsActive
        member this.WbtHasCollided =
            let hasCollidedDrone = Drone (0.0, 0.0, 0.0, 0.0, 0.0)
            printfn "This test will use the drone:\n hasCollidedDrone = Drone (0.0, 0.0, 0.0, 0.0, 0.0)\n"
            printfn "HasCollided should return false at start and it returns: %A" hasCollidedDrone.HasCollided
            hasCollidedDrone.HasCollided <- true
            printfn "HasCollided should return true, when it is changed to true and it returns: %A" hasCollidedDrone.HasCollided
        member this.WbtCurrentDrones =
            let currentDronesDrone = Drone (0.0, 0.0, 0.0, 0.0, 0.0)
            let sndCurrentDronesDrone = Drone (0.0, 0.0, 0.0, 0.0, 0.0)
            let thrdCurrentDronesDrone = Drone (0.0, 0.0, 0.0, 0.0, 0.0)
            let currentDronesAirspace = Airspace [currentDronesDrone; sndCurrentDronesDrone; thrdCurrentDronesDrone]
            let sndCurrentDronesAirspace = Airspace []
            printfn "This test will use the Drones:\n currentDronesDrone = Drone (0.0, 0.0, 0.0, 0.0, 0.0)\n sndCurrentDronesDrone = Drone (0.0, 0.0, 0.0, 0.0, 0.0)\n thrdCurrentDronesDrone = Drone (0.0, 0.0, 0.0, 0.0, 0.0)\n"
            printfn "This test will also use the Airspaces:\n currentDronesAirspace = Airspace [currentDronesDrone; sndCurrentDronesDrone; thrdCurrentDronesDrone]\n sndCurrentDronesAirspace = Airspace []\n"
            printfn "CurrentDrones should return the list [0; 1; 2] when used on currentDronesAirspace and it returns: %A" (currentDronesAirspace.CurrentDrones ())
            printfn "CurrentDrones should return the list [] when used on sndCurrentDronesAirspace and it returns: %A" (sndCurrentDronesAirspace.CurrentDrones ())
        member this.WbtDroneDist =
            let droneDistDrone = Drone (0.0, 0.0, 0.0, 0.0, 0.0)
            let sndDroneDistDrone = Drone (10.0, 10.0, 0.0, 0.0, 0.0)
            let thrdDroneDistDrone = Drone (10.0, 10.0, 0.0, 0.0, 0.0)
            let droneDistAirspace = Airspace [droneDistDrone; sndDroneDistDrone; thrdDroneDistDrone]
            printfn "This test will use the Drones:\n droneDistDrone = Drone (0.0, 0.0, 0.0, 0.0, 0.0)\n sndDroneDistDrone = Drone (10.0, 10.0, 0.0, 0.0, 0.0)\n thrdDroneDistDrone = Drone (10.0, 10.0, 0.0, 0.0, 0.0)\n"
            printfn "This test will also use the Airspace:\n droneDistAirspace = [droneDistDrone; sndDroneDistDrone; thrdDroneDistDrone]\n"
            printfn "DroneDist should return 14.14213562 when used on droneDistDrone & sndDroneDistDrone and it returns: %A" (droneDistAirspace.DroneDist (droneDistDrone, sndDroneDistDrone))
            printfn "DroneDist should return 14.14213562 when used on sndDroneDistDrone & droneDistDrone and it returns: %A" (droneDistAirspace.DroneDist (sndDroneDistDrone, droneDistDrone))
            printfn "DroneDist should return 0.0 when used on snddroneDistDrone & thrdDroneDistDrone and it returns: %A" (droneDistAirspace.DroneDist (sndDroneDistDrone, thrdDroneDistDrone))
            printfn "DroneDist should return 0.0 when used on droneDistDrone & droneDistDrone and it returns: %A" (droneDistAirspace.DroneDist (droneDistDrone, droneDistDrone))
            printfn "The distance used to check with in this test is found using wordmat"
        member this.WbtFlyDrones =
            let flyDronesDrone = Drone (0.0, 0.0, 10.0, 10.0, 5.0)
            let sndFlyDronesDrone = Drone (5.0, 5.0, 10.0, 10.0, 2.5)
            let thrdFlyDronesDrone = Drone (0.0, 0.0, -10.0, -10.0, -5.0)
            let flyDronesAirspace = Airspace [flyDronesDrone; sndFlyDronesDrone; thrdFlyDronesDrone]
            printfn "This test will use the Drones:\n flyDronesDrone = Drone (0.0, 0.0, 10.0, 10.0, 5.0)\n sndFlyDronesDrone = Drone (5.0, 5.0, 10.0, 10.0, 2.5)\n thrdFlyDronesDrone = Drone (0.0, 0.0, -10.0, -10.0, -5.0)\n"
            printfn "This test will also use the Airspace:\n flyDronesAirspace = Airspace [flyDronesDrone; sndFlyDronesDrone; thrdFlyDronesDrone]\n"
            printfn "FlyDrones should move all the drones in the Airspace instance"
            flyDronesAirspace.FlyDrones ()
            printfn "This is the position of all the drones in flyDronesAirspace after FlyDrones has been used:\n flyDronesDrone %A\n sndFlyDronesDrone %A\n thrdFlyDronesDrone %A" flyDronesDrone.Position sndFlyDronesDrone.Position thrdFlyDronesDrone.Position
        member this.WbtAddDrone =
            let addDroneDrone = Drone (0.0, 0.0, 0.0, 0.0, 0.0)
            let sndAddDroneDrone = Drone (0.0, 0.0, 0.0, 0.0, 0.0)
            let addDroneAirspace = Airspace [addDroneDrone]
            printfn "This test will use the Drones:\n addDroneDrone = Drone (0.0, 0.0, 0.0, 0.0, 0.0)\n sndAddDroneDrone = Drone (0.0, 0.0, 0.0, 0.0, 0.0)\n"
            printfn "This test will also use the Airspace:\n addDroneAirspace = Airspace [addDroneDrone]\n"
            printfn "addDroneAirspace currently looks as follows: %A" (addDroneAirspace.CurrentDrones ())
            (addDroneAirspace.AddDrone sndAddDroneDrone)
            printfn "After using AddDrone sndAddDroneDrone on addDroneAirspace then it should look like \"[0; 1]\" and it looks like: %A" (addDroneAirspace.CurrentDrones ())
        member this.WbtWillCollide =
            let willCollideDrone = Drone (0.0, 10.0, 20.0, 10.0, 5.0)
            let sndWillCollideDrone = Drone (20.0, 10.0, 0.0, 10.0, 4.0)
            let thrdWillCollideDrone = Drone (6.0, 10.0, 20.0, 10.0, 4.0)
            let frthWillCollideDrone = Drone (5.0, 5.0, 15.0, 5.0, 5.0)
            let fthWillCollideDrone = Drone (10.0, 10.0, 10.0, 0.0, 5.0)
            let sxthWillCollideDrone = Drone (20.0, 5.0, 5.0, 5.0, 5.0)
            let willCollideAirspace = Airspace [willCollideDrone; sndWillCollideDrone; thrdWillCollideDrone]
            let sndWillCollideAirspace = Airspace [frthWillCollideDrone; fthWillCollideDrone; sxthWillCollideDrone]
            printfn "This test will use the Drones:\n willCollideDrone = drone (0.0, 10.0, 20.0, 10.0, 5.0)\n let sndWillCollideDrone = drone (20.0, 10.0, 0.0, 10.0, 4.0)\n let thrdWillCollideDrone = drone (5.0, 10.0, 20.0, 15.0, 5.0)\n let frthWillCollideDrone = drone (5.0, 5.0, 10.0, 5.0, 1.0)\n fthWillCollideDrone = Drone (10.0, 5.0, 5.0, 5.0, 1.0)\n sxthWillCollideDrone = Drone (0.0, 0.0, 10.0, 0.0, 5.0)\n"
            printfn "This test will also use the Airspaces:\n sndWillCollideAirspace = Airspace [willCollideDrone; frthWillCollideDrone\n willCollideAirspace = Airspace [willCollideDrone; sndWillCollideDrone; thrdWillCollideDrone]\n sndWillCollideAirspace = Airspace [frthWillCollideDrone; fthWillCollideDrone; sxthWillCollideDrone]\n"
            printfn "The IsActive state of all the drones in willCollideAirspace is currently:\n willCollideDrone: %A\n sndWillCollideDrone: %A\n thrdWillCollideDrone: %A\n" willCollideDrone.IsActive sndWillCollideDrone.IsActive thrdWillCollideDrone.IsActive 
            printfn "The HasCollided state of all the drones in willCollideAirspace is currently:\n willCollideDrone: %A\n sndWillCollideDrone: %A\n thrdWillCollideDrone: %A\n" willCollideDrone.HasCollided sndWillCollideDrone.HasCollided thrdWillCollideDrone.HasCollided 
            printfn "The IsFinished state of all the drones in willCollideAirspace is currently:\n willCollideDrone: %A\n sndWillCollideDrone: %A\n thrdWillCollideDrone: %A\n" (willCollideDrone.IsFinished ()) (sndWillCollideDrone.IsFinished ()) (thrdWillCollideDrone.IsFinished ()) 
            printfn "WillCollide should return [] after 1 minute when used on willCollideAirspace and it returns: %A\n" (willCollideAirspace.WillCollide 1)
            printfn "The distance between willCollide & sndWillCollide: %A\nThe distance between willCollide & thrdWillCollide: %A\nThe distance between sndwillCollide & thrdWillCollide: %A" (willCollideAirspace.DroneDist (willCollideDrone, sndWillCollideDrone)) (willCollideAirspace.DroneDist (willCollideDrone, thrdWillCollideDrone)) (willCollideAirspace.DroneDist (sndWillCollideDrone, thrdWillCollideDrone))
            printfn "\nThe IsActive state of all the drones in willCollideAirspace after 1 minute:\n willCollideDrone: %A\n sndWillCollideDrone: %A\n thrdWillCollideDrone: %A\n" willCollideDrone.IsActive sndWillCollideDrone.IsActive thrdWillCollideDrone.IsActive 
            printfn "The HasCollided state of all the drones in willCollideAirspace after 1 minute:\n willCollideDrone: %A\n sndWillCollideDrone: %A\n thrdWillCollideDrone: %A\n" willCollideDrone.HasCollided sndWillCollideDrone.HasCollided thrdWillCollideDrone.HasCollided 
            printfn "The IsFinished state of all the drones in willCollideAirspace after 1 minute:\n willCollideDrone: %A\n sndWillCollideDrone: %A\n thrdWillCollideDrone: %A\n" (willCollideDrone.IsFinished ()) (sndWillCollideDrone.IsFinished ()) (thrdWillCollideDrone.IsFinished ())
            printfn "WillCollide should return [(0, 1); (0, 2); (1, 2)] after another minute when used on willCollideAirspace again and it returns: %A\n" (willCollideAirspace.WillCollide 1)
            printfn "The distance between willCollide & sndWillCollide: %A\nThe distance between willCollide & thrdWillCollide: %A\nThe distance between sndwillCollide & thrdWillCollide: %A" (willCollideAirspace.DroneDist (willCollideDrone, sndWillCollideDrone)) (willCollideAirspace.DroneDist (willCollideDrone, thrdWillCollideDrone)) (willCollideAirspace.DroneDist (sndWillCollideDrone, thrdWillCollideDrone))
            printfn "\nThe IsActive state of all the drones in willCollideAirspace after 2 minutes:\n willCollideDrone: %A\n sndWillCollideDrone: %A\n thrdWillCollideDrone: %A\n" willCollideDrone.IsActive sndWillCollideDrone.IsActive thrdWillCollideDrone.IsActive 
            printfn "The HasCollided state of all the drones in willCollideAirspace after 2 minutes:\n willCollideDrone: %A\n sndWillCollideDrone: %A\n thrdWillCollideDrone: %A\n" willCollideDrone.HasCollided sndWillCollideDrone.HasCollided thrdWillCollideDrone.HasCollided 
            printfn "The IsFinished state of all the drones in willCollideAirspace after 2 minutes:\n willCollideDrone: %A\n sndWillCollideDrone: %A\n thrdWillCollideDrone: %A\n" (willCollideDrone.IsFinished ()) (sndWillCollideDrone.IsFinished ()) (thrdWillCollideDrone.IsFinished ())
            
            printfn "Now using sndWillCollideAirspace instance:\n"

            printfn "The IsActive state of all the drones in sndWillCollideAirspace is currently:\n frthWillCollideDrone: %A\n fthWillCollideDrone: %A\n sxthWillCollideDrone: %A\n" frthWillCollideDrone.IsActive fthWillCollideDrone.IsActive sxthWillCollideDrone.IsActive 
            printfn "The HasCollided state of all the drones in sndWillCollideAirspace is currently:\n frthWillCollideDrone: %A\n fthWillCollideDrone: %A\n sxthWillCollideDrone: %A\n" frthWillCollideDrone.HasCollided fthWillCollideDrone.HasCollided sxthWillCollideDrone.HasCollided 
            printfn "The IsFinished state of all the drones in sndWillCollideAirspace is currently:\n frthWillCollideDrone: %A\n fthWillCollideDrone: %A\n sxthWillCollideDrone: %A\n" (willCollideDrone.IsFinished ()) (fthWillCollideDrone.IsFinished ()) (sxthWillCollideDrone.IsFinished ()) 
            printfn "WillCollide should return [(0, 1)] after 1 minute when used on sndWillCollideAirspace and it returns: %A\n" (sndWillCollideAirspace.WillCollide 1)
            printfn "The distance between frthWillCollide & fthWillCollide: %A\nThe distance between frthWillCollide & sxthWillCollide: %A\nThe distance between fthWillCollide & sxthWillCollide: %A" (sndWillCollideAirspace.DroneDist (frthWillCollideDrone, fthWillCollideDrone)) (sndWillCollideAirspace.DroneDist (frthWillCollideDrone, sxthWillCollideDrone)) (sndWillCollideAirspace.DroneDist (fthWillCollideDrone, sxthWillCollideDrone))
            printfn "\nThe IsActive state of all the drones in sndWillCollideAirspace after 1 minute:\n frthWillCollideDrone: %A\n fthWillCollideDrone: %A\n sxthWillCollideDrone: %A\n" frthWillCollideDrone.IsActive fthWillCollideDrone.IsActive sxthWillCollideDrone.IsActive 
            printfn "The HasCollided state of all the drones in sndWillCollideAirspace after 1 minute:\n frthWillCollideDrone: %A\n fthWillCollideDrone: %A\n sxthWillCollideDrone: %A\n" frthWillCollideDrone.HasCollided fthWillCollideDrone.HasCollided sxthWillCollideDrone.HasCollided 
            printfn "The IsFinished state of all the drones in sndWillCollideAirspace after 1 minute:\n frthWillCollideDrone: %A\n fthWillCollideDrone: %A\n sxthWillCollideDrone: %A\n" (willCollideDrone.IsFinished ()) (fthWillCollideDrone.IsFinished ()) (sxthWillCollideDrone.IsFinished ())
            printfn "WillCollide should return [] after another minute when used on sndWillCollideAirspace again and it returns: %A\n" (sndWillCollideAirspace.WillCollide 1)
            printfn "The distance between frthWillCollide & fthWillCollide: %A\nThe distance between frthWillCollide & sxthWillCollide: %A\nThe distance between fthWillCollide & sxthWillCollide: %A" (sndWillCollideAirspace.DroneDist (frthWillCollideDrone, fthWillCollideDrone)) (sndWillCollideAirspace.DroneDist (frthWillCollideDrone, sxthWillCollideDrone)) (sndWillCollideAirspace.DroneDist (fthWillCollideDrone, sxthWillCollideDrone))
            printfn "\nThe IsActive state of all the drones in sndWillCollideAirspace after 2 minutes:\n frthWillCollideDrone: %A\n fthWillCollideDrone: %A\n sxthWillCollideDrone: %A\n" frthWillCollideDrone.IsActive fthWillCollideDrone.IsActive sxthWillCollideDrone.IsActive 
            printfn "The HasCollided state of all the drones in sndWillCollideAirspace after 2 minutes:\n frthWillCollideDrone: %A\n fthWillCollideDrone: %A\n sxthWillCollideDrone: %A\n" frthWillCollideDrone.HasCollided fthWillCollideDrone.HasCollided sxthWillCollideDrone.HasCollided 
            printfn "The IsFinished state of all the drones in sndWillCollideAirspace after 2 minutes:\n frthWillCollideDrone: %A\n fthWillCollideDrone: %A\n sxthWillCollideDrone: %A\n" (frthWillCollideDrone.IsFinished ()) (fthWillCollideDrone.IsFinished ()) (sxthWillCollideDrone.IsFinished ())

let wbt = WhiteBoxTest()
printfn "\nThis is the white-box test of Fly:\n"
wbt.WbtFly

printfn "\nThis is the white-box test of IsActive:\n"
wbt.WbtIsActive

printfn "\nThis is the white-box test of HasCollided:\n"
wbt.WbtHasCollided

printfn "\nThis is the white-box test of CurrentDrones:\n"
wbt.WbtCurrentDrones

printfn "\nThis is the white-box test of DroneDist:\n"
wbt.WbtDroneDist

printfn "\nThis is the white-box test of FlyDrones:\n"
wbt.WbtFlyDrones

printfn "\nThis is the white-box test of AddDrone:\n"
wbt.WbtAddDrone

printfn "\nThis is the white-box test of WillCollide:\n"
wbt.WbtWillCollide
