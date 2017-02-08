namespace FSharp.Data

open ProviderImplementation.ProvidedTypes
open Microsoft.FSharp.Core.CompilerServices
open System.Reflection

[<TypeProvider>]
type DbfTypeProvider (config: TypeProviderConfig) as this = 
    inherit TypeProviderForNamespaces ()
    
    let ns = this.GetType().Namespace
    let asm = Assembly.GetExecutingAssembly()

    let createTypes () =
        let rootType = ProvidedTypeDefinition(asm, ns, "DbfConnection", Some typeof<obj>)
        let testProp = ProvidedProperty("MyProperty", typeof<string>, IsStatic = true, GetterCode = (fun args -> <@@ "Hello world!" @@>))
        rootType.AddMember(testProp)
        [rootType]

    do
        this.AddNamespace(ns, createTypes ())

[<assembly:TypeProviderAssembly>]
do ()