## Spend Time

| Part                          | Spend Time (H) |
|-------------------------------|----------------|
| initialize project            | 1.5            |
| add quotes api                | 4              |
| dockerize project             | 0.5            |
| cache mechanism               | 1              |
| validation mechanism          | 1.5            |
| test structure implementation | 2              |
| refactor and in-memory cache  | 0.5            |
| total                         | 11             |

## Need to Add

- add circuit breaker and retry mechanism for external adapter
- add rate limiting mechanism (based on ip in every controllers)
- add last_update_time in flow and update every time API call succeed
- handle external adapter exceptions (create enum from all error codes in external api and map it to internal exceptions)

## Performance Issue in Production

we use sentry in production environment

- filter transactions with a time duration exceeding the 95th
- check the transaction trace view for the slowest transaction
- identify the section that took the most time and review it

## Technical Book

System Design Interview

- consistent hashing (the mechanism of a hash ring involves identifying the positions of hash keys and servers on it)

## New in .Net8

Record

```csharp
public record LatestQuoteInput(string Symbol, string Convert);
```

## Assessment

I believe the assessment includes most of the challenges we encountered while designing service APIs


## Introduce

```json
{
  "name": "ahmadreza",
  "familyName": "nani",
  "displayName": "ahmadreza nani",
  "email": "ahmadr4079@gmail.com",
  "phone_number": "00989217854001",
  "birthday_date": "1997-06-11",
  "education": [
    {
      "degree": "bachelor",
      "institution": "arak university",
      "graduation_year": "2020"
    }
  ],
  "hobbies": ["playing_music", "watching_movies"]
}
```