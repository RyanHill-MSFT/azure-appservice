import { AzureFunction, Context } from "@azure/functions"

const transmissionReceived: AzureFunction = async function transmissionReceived(context: Context, transmissionReceived: any) {
    context.log(`Subspace messaged received from ${transmissionReceived.ConnectionId}`);
    context.log(`Message: ${context.bindingData.message}`);
}

export default transmissionReceived;