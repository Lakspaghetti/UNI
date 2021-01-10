type weekday = Monday | Tuesday | Wednesday | Thursday | Friday | Saturday | Sunday

let dayToNumber (d: weekday) : int = 
    match d with
    | Monday -> 1
    | Tuesday -> 2
    | Wednesday -> 3
    | Thursday -> 4
    | Friday ->  5
    | Saturday -> 6
    | Sunday -> 7

printfn "dayToNumber returns %A when it's Monday" (dayToNumber Monday)