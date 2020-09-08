using GW.AspNetTraining.TrainingsWebApp.Business;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace TrainingsTest
{
    class OrderProcessorTestData
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new List<AttendeeEntity>{ 
                    new AttendeeEntity(),
                    new AttendeeEntity(),
                    new AttendeeEntity() }, 100m, 240m);

                yield return new TestCaseData(new List<AttendeeEntity>{
                    new AttendeeEntity(),
                    new AttendeeEntity(),
                    new AttendeeEntity(),
                    new AttendeeEntity() }, 100m, 320m);

                yield return new TestCaseData(new List<AttendeeEntity>{
                    new AttendeeEntity(),
                    new AttendeeEntity(),
                    new AttendeeEntity(),
                    new AttendeeEntity() }, 80m, 256m );
            }
        }

        public static IEnumerable TestCasesWithResult
        {
            get
            {
                yield return new TestCaseData(new List<AttendeeEntity>{
                    new AttendeeEntity(),
                    new AttendeeEntity(),
                    new AttendeeEntity() }, 100m).Returns(240);

                yield return new TestCaseData(new List<AttendeeEntity>{
                    new AttendeeEntity(),
                    new AttendeeEntity(),
                    new AttendeeEntity(),
                    new AttendeeEntity() }, 100m).Returns(320);

                yield return new TestCaseData(new List<AttendeeEntity>{
                    new AttendeeEntity(),
                    new AttendeeEntity(),
                    new AttendeeEntity(),
                    new AttendeeEntity() }, 80m).Returns(256m);
            }
        }
    }
}

