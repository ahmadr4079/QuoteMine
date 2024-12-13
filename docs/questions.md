## Time Spend

| Part                 | Spend Time (H) |
|----------------------|----------------|
| initialize project   | 1.5            |
| add quotes api       | 4              |
| dockerize project    | 0.5            |
| cache mechanism      | 1              |
| validation mechanism | 1.5            |
| total                | 10             |

## Need to add

- add circuit breaker and retry mechanism
- add rate limiting mechanism
- change flow to have response when redis is down

## Performance Issue in Production

we use sentry in production environment

- filter transactions with a time duration exceeding the 95th
- check the transaction trace view for the slowest transaction
- identify the section that took the most time and review it
- API test
- error handling infrastructure

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