/* 
 * NewTumbl.Login.ts
 * 
 *   Created: 2023-03-08-10:44:42
 *   Modified: 2023-03-08-10:44:43
 * 
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *   
 *   Copyright © 2022-2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

import { CookieJar, Store } from "tough-cookie";
import { FileCookieStore } from "tough-cookie-filestoree";
import JSDOM, { ResourceLoader } from "jsdom";
import { ApiEndpoint } from "./ApiEndpoint";
import { ApiBaseUrls } from "./ApiBaseUrls";

class NewTumbl {
    private _username: string;
    private _password: string;
    private _cookieJar: CookieJar;
    constructor(username: string, password: string) {
        this._username = username;
        this._password = password;
        this._cookieJar = new CookieJar(new FileCookieStore(`~/.cookies/newtumbl/${this._username}`));
    }

    public async login() {
        var jsdom = await JSDOM.JSDOM.fromURL(`${ApiBaseUrls.rwBase}.${ApiEndpoint.set_User_Login}`,
            {
                cookieJar: this._cookieJar,
                referrer: ApiBaseUrls.referrer,
                runScripts: "dangerously",
                ""
            resources: new ResourceLoader(
                    {
                        strictSSL: true,
                        userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.114 Safari/537.36",
                        proxy: undefined
                    }
                )
            });
        console.log(jsdom.window.document);
    }
}
