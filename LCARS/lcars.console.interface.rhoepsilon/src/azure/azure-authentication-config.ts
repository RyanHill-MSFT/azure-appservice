import { Configuration, LogLevel } from "@azure/msal-browser";

const aadClientId: any = process.env.REACT_APP_CLIENT_ID;
const aadAuthority: any = `https://login.microsoftonline.com/${process.env.REACT_APP_TENANT}`; // This is a URL (e.g. https://login.microsoftonline.com/{your tenant ID})
const aadRedirectUri: any = process.env.REACT_APP_REDIRECT_URI;

export const MSAL_CONFIG: Configuration = {
    auth: {
        clientId: aadClientId,
        authority: aadAuthority,
        redirectUri: aadRedirectUri
    },
    cache: {
        cacheLocation: "sessionStorage", // This configures where your cache will be stored
        storeAuthStateInCookie: false, // Set this to "true" if you are having issues on IE11 or Edge
    },
    system: {
        loggerOptions: {
            loggerCallback: (level: any, message: any, containsPii: boolean): void => {
                if (containsPii) {
                    return;
                }
                switch (level) {
                    case LogLevel.Error:
                        console.error(message);
                        return;
                    case LogLevel.Info:
                        console.info(message);
                        return;
                    case LogLevel.Verbose:
                        console.debug(message);
                        return;
                    case LogLevel.Warning:
                        console.warn(message);
                        return;
                }
            }
        }
    }
};