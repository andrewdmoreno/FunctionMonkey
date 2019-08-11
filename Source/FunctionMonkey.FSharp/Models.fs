namespace FunctionMonkey.FSharp
open System
open FunctionMonkey.Abstractions
open FunctionMonkey.Abstractions.Builders
open FunctionMonkey.Abstractions.Builders.Model
open FunctionMonkey.Abstractions.Http

module Models =
    type IFunctionHandler = interface end
    type Handler<'commandType, 'commandResult> =
        {        
            handler: 'commandType -> 'commandResult
        }
        interface IFunctionHandler
        
    type OutputAuthoredSource =
        | Path of string
        | NoSourceOutput
        
    type FunctionCompilerMetadata =
         {
             functionDefinitions: AbstractFunctionDefinition list
             openApiConfiguration: OpenApiConfiguration
             outputAuthoredSourceFolder: OutputAuthoredSource
         }
         interface IFunctionCompilerMetadata with
            member i.FunctionDefinitions = i.functionDefinitions :> System.Collections.Generic.IReadOnlyCollection<AbstractFunctionDefinition>
            member i.OpenApiConfiguration = i.openApiConfiguration
            member i.OutputAuthoredSourceFolder = match i.outputAuthoredSourceFolder with | Path p -> p | NoSourceOutput -> null
        
    type HttpVerb =
            | Get
            | Put
            | Post
            | Patch
            | Delete
            //| Custom of string
    type HttpRoute =
        | Path of string
        | Unspecified
    type HttpFunction =
        {
            commandType: Type
            resultType: Type
            handler: IFunctionHandler
            verbs: HttpVerb list
            route: HttpRoute
        }
        
    type Authorization =
        {
            defaultAuthorizationMode: AuthorizationTypeEnum
            defaultAuthorizationHeader: string
        }
    
    type Functions = {
        httpFunctions: HttpFunction list 
    }
    
    type FunctionAppConfiguration = {
        authorization: Authorization       
        functions: Functions
    }

