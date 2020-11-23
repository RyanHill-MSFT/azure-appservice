import { AzureFunction, Context } from "@azure/functions"

const queueTrigger: AzureFunction = async function (context: Context, subspaceMessage: string): Promise<void> {
    context.log('Subspace message received...', subspaceMessage);
    try {
        context.bindings.subspaceRelay = [{
            "target": "subspaceMessage",
            "arguments": [subspaceMessage]
        }];
        context.log('Transmitted...');
    } catch (error) {
        context.log('Transmission error: ', error);
    }
    context.done();
};

export default queueTrigger;