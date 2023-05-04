-> main

=== main ===
How are you feeling today?
    + [Tired]
        -> chosen("Tired")
    + [Energetic]
        -> chosen("Energetic")
            

=== chosen(selection) ===
You chose {selection}
-> END