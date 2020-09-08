using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD
{
    [TestFixture]
    public class FizzBuzzTests
    {
        FizzBuzz _sut;

        [SetUp]
        public void Init()
        {
            _sut = new FizzBuzz();
        }

        [Test]
        public void WennEineZahlÜbergebenWirdTextZurückgegeben()
        {
            var result = _sut.Calc(1);
            result.Should().Be("1");
        }

        //[Test]
        //public void Wenn2ÜbergebenWirdZweiZurückgeben()
        //{
        //    var result = _sut.Calc(2);
        //    result.Should().Be("2");
        //}

        [Test]
        public void WennGanzzahligDurchDreiTeilbarUndNichtGanzzahligDurchFünfFizzZurückgeben()
        {
            var result = _sut.Calc(3);
            result.Should().Be("Fizz");
        }

        [Test]
        public void WennGanzzahligDurchFünfTeilbarBuzzZurückgeben()
        {
            var result = _sut.Calc(5);
            result.Should().Be("Buzz");
        }

        [Test]
        public void WennGanzzahligDurchFünfzehnTeilbarFizzBuzzZurückgeben()
        {
            var result = _sut.Calc(15);
            result.Should().Be("FizzBuzz");
        }

        
    }
}
