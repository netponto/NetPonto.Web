
Properties {
    
}


Task Default -depends Build
Task Setup -depends FetchDependencies

Task FetchDependencies {
    nu install fluentnhibernate --version 1.1.0.685
    nu install sparkviewengine --version 1.1.0.0
    nu install autofac --version 2.2.4.900
    nu install elmah --version 1.1.11517.0.20100822
    nu install automapper --version 1.1.0.188.20100804
}

Task SetupMembershipTables {
    aspnet_regsql.exe -E -S localhost -A mr -d netponto
}