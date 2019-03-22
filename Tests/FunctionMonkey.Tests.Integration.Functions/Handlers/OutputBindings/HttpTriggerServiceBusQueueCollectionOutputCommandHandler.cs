﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using FunctionMonkey.Tests.Integration.Functions.Commands.Model;
using FunctionMonkey.Tests.Integration.Functions.Commands.OutputBindings;

namespace FunctionMonkey.Tests.Integration.Functions.Handlers.OutputBindings
{
    class HttpTriggerServiceBusQueueCollectionOutputCommandHandler : ICommandHandler<HttpTriggerServiceBusQueueCollectionOutputCommand, IReadOnlyCollection<SimpleResponse>>
    {
        public Task<IReadOnlyCollection<SimpleResponse>> ExecuteAsync(HttpTriggerServiceBusQueueCollectionOutputCommand command, IReadOnlyCollection<SimpleResponse> previousResult)
        {
            return SimpleResponse.SuccessCollection();
        }
    }
}