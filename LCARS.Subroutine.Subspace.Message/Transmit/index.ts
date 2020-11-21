import { AzureFunction, Context } from "@azure/functions"

const queueTrigger: AzureFunction = async function (context: Context, message: string): Promise<void> {
    context.log('Subspace message received...', message);
    context.log('Ready for transmission...')
};

export default queueTrigger;
