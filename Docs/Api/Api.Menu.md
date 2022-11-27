## Create Menu

### Create Menu Request

```js
POST /host/{hostId}/menus
```

```json
{
    "name":"Yummy Menu",
    "description":"A menu with yummy food",
    "sections":[
        {
            "name":"Appetizers",
            "description":"Starters",
            "items":[
                {
                    "name":"Fried Pickles",
                    "description":"Deep fried pickles"                
                }
            ]
        }
    ]
}
```
