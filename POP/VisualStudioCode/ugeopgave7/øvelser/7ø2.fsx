type weekday = Monday | Tuesday | Wednesday | Thursday | Friday | Saturday | Sunday

let nextDay (d: weekday) : weekday = 
    match d with
    | Monday -> Tuesday
    | Tuesday -> Wednesday
    | Wednesday -> Thursday
    | Thursday -> Friday
    | Friday ->  Saturday
    | Saturday -> Sunday
    | Sunday -> Monday

printfn "\n nextDay returns %A when it's Monday\n"  (nextDay Monday)
printfn  "nextDay returns %A when it's Sunday\n"  (nextDay Sunday)