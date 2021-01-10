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

printfn "\ndayToNumber returns %A when it's Monday" (dayToNumber Monday)

let numberToDay (i: int) : (weekday) option = 
    match i with
    | 1 -> Some(Monday)
    | 2 -> Some(Tuesday)
    | 3 -> Some(Wednesday)
    | 4 -> Some(Thursday)
    | 5 -> Some(Friday)
    | 6 -> Some(Saturday)
    | 7 -> Some(Sunday)
    | _ -> None
printfn "\nnumberToDay returns \"%A\" when it's 1\n"  (numberToDay 1)
printfn  "numberToDay returns \"%A\" when it's 7\n"  (numberToDay 7)
printfn  "numberToDay returns \"%A\" when it's above 7\n"  (numberToDay 8)
printfn  "numberToDay returns \"%A\" when it's beneath 1\n"  (numberToDay 0)