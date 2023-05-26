namespace domain

module models =
    type Bread(name: string) =
        let breadId = System.Guid.NewGuid().ToString()
        let breadName = name
        


        let print : string = $"Bread ID: {breadId}; name: {breadName}"