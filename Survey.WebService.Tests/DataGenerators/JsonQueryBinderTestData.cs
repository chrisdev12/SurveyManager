using Survey.WebService.Models.DTOs;
using System.Collections.Generic;

namespace Survey.WebService.UnitTests.DataGenerators
{
    public class JsonQueryBinderTestData
    {
        public static IEnumerable<object[]> GetGeneralSurveyRequestDtoAsJsonString()
        {
            yield return new object[]
            {
                "{" +
                    "\"survey\":{" +
                        "\"id\":\"Starcsadf\"," +
                        "\"description\":\"Stars Medicare Survey was updated\"" +
                    "}," +
                    "\"questions\":[" +
                        "{\"id\":\"1\",\"description\":\"In the last 6 months, how often did you make an appointment with your primary care physician as soon as you needed one test\"}" +
                        ",{\"id\":\"2\",\"description\":\"In the last 6 months, how often did you wait 15 minutes or less for the doctor to see you?\"}" +
                        ",{\"id\":\"3\",\"description\":\"In the last 6 months, how often did you receive assistance from the doctor\u2019s office staff to coordinate appointments with other providers and medical services if needed?\"}" +
                        ",{\"id\":\"4\",\"description\":\"In the last 6 months, how often was it easy for you to get the medical care, tests or treatment you needed?\"}" +
                        ",{\"id\":\"5\",\"description\":\"In the last 6 months, when you needed immediate attention, how often were you seen as soon as you needed it?\"}" +
                        ",{\"id\":\"6\",\"description\":\"In the last 6 months, how often did your primary care physician seem to be informed and aware of the care you received from specialists?\"}" +
                        ",{\"id\":\"7\",\"description\":\"What number would you use to rate your primary physician? Mark a digit from 0 to 9 where 0 is the worst possible primary physician and 9 is the best possible primary physician.\"}" +
                        ",{\"id\":\"8\",\"description\":\"Want to keep receiving this calls?\"}" +
                    "]" +
                    ",\"answers\":[" +
                        "{\"answerId\":\"1\",\"phoneDigit\":\"4\",\"description\":\"never\"}," +
                        "{\"answerId\":\"2\",\"phoneDigit\":\"4\",\"description\":\"never\"}," +
                        "{\"answerId\":\"3\",\"phoneDigit\":\"2\",\"description\":\"most of the time\"}," +
                        "{\"answerId\":\"4\",\"phoneDigit\":\"1\",\"description\":\"always\"}," +
                        "{\"answerId\":\"5\",\"phoneDigit\":\"4\",\"description\":\"never\"}," +
                        "{\"answerId\":\"6\",\"phoneDigit\":\"2\",\"description\":\"most of the time\"}," +
                        "{\"answerId\":\"7\",\"phoneDigit\":\"9\",\"description\":\"9\"}," +
                        "{\"answerId\":\"8\",\"phoneDigit\":\"1\",\"description\":\"yes\"}" +
                    "]," +
                    "\"memberInfo\":{" +
                        "\"memberNumber\":\"55555555\"" +
                        ",\"memberName\":\"Chris Test\"" +
                        ",\"phoneNumber\":\"7872326831\"" +
                        ",\"phoneNumber1\":\"\"" +
                        ",\"providerName\":\"VELAZQUEZ LOZADA IDIA L\"" +
                        ",\"providerNPI\":\"1376570499\"" +
                        ",\"IPA\":\"968\"" +
                        ",\"language\":\"ENG\"" +
                        ",\"calldate\":\"2021-09-21 15:01:37\"" +
                        ",\"disposition\":\"CCSC\"" +
                    "}" +
                "}",
                new GeneralSurveyRequestDTO()
            };
        }
    }
}