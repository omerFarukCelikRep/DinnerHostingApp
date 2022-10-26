# Domain Models

## Menu

```csharp
class Menu
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection section);
}
```

```json
{
    "id":"00000000-0000-0000-0000-000000000000",
    "name":"Yummy Menu",
    "description":"A menu with yummy food",
    "averageRating":4.5
    "sections":[
        {
            "id":"00000000-0000-0000-0000-000000000000",
            "name":"Appetizers",
            "description":"Starters",
            "items":[
                {
                    "id":"00000000-0000-0000-0000-000000000000",
                    "name":"Fried Pickles",
                    "description":"Deep fried pickles",
                    "price":5.99
                }
            ]
        }
    ],
    "createdDateTime":"2022-10-26T00:00:00.000000Z",
    "updatedDateTime":"2022-10-26T00:00:00.000000Z",
    "hostId":"00000000-0000-0000-0000-000000000000",
    "dinnerIds":["00000000-0000-0000-0000-000000000000"],
    "menuReviewIds":["00000000-0000-0000-0000-000000000000"]
}
```
