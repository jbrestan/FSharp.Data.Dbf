namespace FSharp.Data.TypeProviders

open ProviderImplementation.ProvidedTypes
open Microsoft.FSharp.Core.CompilerServices
open System.Reflection

[<TypeProvider>]
type DbfConnection (config: TypeProviderConfig) as this = 
    inherit TypeProviderForNamespaces ()
    member this.X = "F#"

[<assembly:TypeProviderAssembly>]
do ()