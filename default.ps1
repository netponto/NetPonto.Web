
Properties {
    
}


Task Default -depends Build
Task Setup -depends FetchDependencies

Task FetchDependencies {
    nu install fluentnhibernate --version 1.1.0.685
    nu install sparkviewengine --version 1.1.0.0
    nu install elmah --version 1.1.11517.0.20100822
}