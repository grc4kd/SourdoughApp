namespace domain.models
    type Bread(name: string) =
        let breadId = System.Guid.NewGuid().ToString()
        let breadName = name
           
        // TODO: something more useful instead of print
        let print : string = $"Bread ID: {breadId}; name: {breadName}"