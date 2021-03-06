namespace StripeTests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Stripe;
    using Xunit;

    public class StripeCouponServiceTest : BaseStripeTest
    {
        private const string CouponId = "co_123";

        private StripeCouponService service;
        private StripeCouponCreateOptions createOptions;
        private StripeCouponUpdateOptions updateOptions;
        private StripeCouponListOptions listOptions;

        public StripeCouponServiceTest()
        {
            this.service = new StripeCouponService();

            this.createOptions = new StripeCouponCreateOptions()
            {
                PercentOff = 25,
                Duration = "forever",
            };

            this.updateOptions = new StripeCouponUpdateOptions()
            {
                Metadata = new Dictionary<string, string>()
                {
                    { "key", "value" },
                },
            };

            this.listOptions = new StripeCouponListOptions()
            {
                Limit = 1,
            };
        }

        [Fact]
        public void Create()
        {
            var coupon = this.service.Create(this.createOptions);
            Assert.NotNull(coupon);
            Assert.Equal("coupon", coupon.Object);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var coupon = await this.service.CreateAsync(this.createOptions);
            Assert.NotNull(coupon);
            Assert.Equal("coupon", coupon.Object);
        }

        [Fact]
        public void Delete()
        {
            var deleted = this.service.Delete(CouponId);
            Assert.NotNull(deleted);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var deleted = await this.service.DeleteAsync(CouponId);
            Assert.NotNull(deleted);
        }

        [Fact]
        public void Get()
        {
            var coupon = this.service.Get(CouponId);
            Assert.NotNull(coupon);
            Assert.Equal("coupon", coupon.Object);
        }

        [Fact]
        public async Task GetAsync()
        {
            var coupon = await this.service.GetAsync(CouponId);
            Assert.NotNull(coupon);
            Assert.Equal("coupon", coupon.Object);
        }

        [Fact]
        public void List()
        {
            var coupons = this.service.List(this.listOptions);
            Assert.NotNull(coupons);
            Assert.Equal("list", coupons.Object);
            Assert.Single(coupons.Data);
            Assert.Equal("coupon", coupons.Data[0].Object);
        }

        [Fact]
        public async Task ListAsync()
        {
            var coupons = await this.service.ListAsync(this.listOptions);
            Assert.NotNull(coupons);
            Assert.Equal("list", coupons.Object);
            Assert.Single(coupons.Data);
            Assert.Equal("coupon", coupons.Data[0].Object);
        }

        [Fact]
        public void Update()
        {
            var coupon = this.service.Update(CouponId, this.updateOptions);
            Assert.NotNull(coupon);
            Assert.Equal("coupon", coupon.Object);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var coupon = await this.service.UpdateAsync(CouponId, this.updateOptions);
            Assert.NotNull(coupon);
            Assert.Equal("coupon", coupon.Object);
        }
    }
}
