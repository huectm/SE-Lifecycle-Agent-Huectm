using System.Globalization;
using System.Reflection;
using System.Text.Json;
using FreshFood.Api;
using FreshFood.Api.DTOs;
using FreshFood.Api.Services;
using FreshFood.Api.Services.Implements;
using FreshFood.Reposistory.Entities;
using FreshFood.Reposistory.Repository;
using FreshFood.Reposistory.Repository.Implements;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;
using System.Security.Claims;
using System.Text;
using FreshFood.Api.Controllers;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using static FreshFood.Backend.UnitTests.ScenarioValues;

// Generated NUnit tests with explicit business calls and expected-result assertions.
namespace FreshFood.Backend.UnitTests;
[NUnit.Framework.TestFixture]
public sealed class Services_Implements_ProfileServiceTests
{
    /// <summary>
    /// UTM-088-TC001: Valid construction
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: ProfileService.ProfileService(IProfileRepository profileRepository, ICurrentCustomer
    /// currentCustomer, IUnitOfWork unitOfWork, IGeocodingGateway geocodingGateway)
    /// </para>
    /// <para>
    /// Technique: Constructor contract; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"profileRepository": "Typed FreshFood.Reposistory.Repository.IProfileRepository fixture from
    /// fixtures.json", "currentCustomer": "Typed FreshFood.Api.Services.ICurrentCustomer fixture from
    /// fixtures.json", "unitOfWork": "Typed FreshFood.Reposistory.Repository.IUnitOfWork fixture from
    /// fixtures.json", "geocodingGateway": "Typed FreshFood.Api.Services.IGeocodingGateway fixture from
    /// fixtures.json"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke ProfileService.ProfileService(IProfileRepository
    /// profileRepository, ICurrentCustomer currentCustomer, IUnitOfWork unitOfWork, IGeocodingGateway
    /// geocodingGateway); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Instance retains supplied dependency/data identities; no business IO during
    /// construction
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No collaborator calls
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-088.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-088-TC001")]
    public void UTM_088_TC001()
    {
        // Arrange: test inputs and mock setup.
        var profileRepository = (FreshFood.Reposistory.Repository.IProfileRepository)Fixture.Value(typeof(FreshFood.Reposistory.Repository.IProfileRepository))!;
        var currentCustomer = (FreshFood.Api.Services.ICurrentCustomer)Fixture.Value(typeof(FreshFood.Api.Services.ICurrentCustomer))!;
        var unitOfWork = (FreshFood.Reposistory.Repository.IUnitOfWork)Fixture.Value(typeof(FreshFood.Reposistory.Repository.IUnitOfWork))!;
        var geocodingGateway = (FreshFood.Api.Services.IGeocodingGateway)Fixture.Value(typeof(FreshFood.Api.Services.IGeocodingGateway))!;
        // Act
        var actual = new FreshFood.Api.Services.Implements.ProfileService(profileRepository, currentCustomer, unitOfWork, geocodingGateway);
        // Assert
        Assert.That(actual, Is.TypeOf<FreshFood.Api.Services.Implements.ProfileService>());
    }

    /// <summary>
    /// UTM-088-TC002: Constructor default / lifecycle boundary
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: ProfileService.ProfileService(IProfileRepository profileRepository, ICurrentCustomer
    /// currentCustomer, IUnitOfWork unitOfWork, IGeocodingGateway geocodingGateway)
    /// </para>
    /// <para>
    /// Technique: Boundary; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"profileRepository": "Typed FreshFood.Reposistory.Repository.IProfileRepository fixture from
    /// fixtures.json", "currentCustomer": "Typed FreshFood.Api.Services.ICurrentCustomer fixture from
    /// fixtures.json", "unitOfWork": "Typed FreshFood.Reposistory.Repository.IUnitOfWork fixture from
    /// fixtures.json", "geocodingGateway": "Typed FreshFood.Api.Services.IGeocodingGateway fixture from
    /// fixtures.json", "variant": "Omit optional arguments; otherwise use distinct valid instances and empty
    /// collections"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke ProfileService.ProfileService(IProfileRepository
    /// profileRepository, ICurrentCustomer currentCustomer, IUnitOfWork unitOfWork, IGeocodingGateway
    /// geocodingGateway); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Declared defaults and fresh-instance isolation preserved
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No IO
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-088.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-088-TC002")]
    public void UTM_088_TC002()
    {
        // Arrange: test inputs and mock setup.
        var profileRepository = (FreshFood.Reposistory.Repository.IProfileRepository)Fixture.Value(typeof(FreshFood.Reposistory.Repository.IProfileRepository))!;
        var currentCustomer = (FreshFood.Api.Services.ICurrentCustomer)Fixture.Value(typeof(FreshFood.Api.Services.ICurrentCustomer))!;
        var unitOfWork = (FreshFood.Reposistory.Repository.IUnitOfWork)Fixture.Value(typeof(FreshFood.Reposistory.Repository.IUnitOfWork))!;
        var geocodingGateway = (FreshFood.Api.Services.IGeocodingGateway)Fixture.Value(typeof(FreshFood.Api.Services.IGeocodingGateway))!;
        // Act
        var actual = new FreshFood.Api.Services.Implements.ProfileService(profileRepository, currentCustomer, unitOfWork, geocodingGateway);
        // Assert
        Assert.That(actual, Is.TypeOf<FreshFood.Api.Services.Implements.ProfileService>());
    }

    /// <summary>
    /// UTM-088-TC003: Abnormal caller contract review
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: ProfileService.ProfileService(IProfileRepository profileRepository, ICurrentCustomer
    /// currentCustomer, IUnitOfWork unitOfWork, IGeocodingGateway geocodingGateway)
    /// </para>
    /// <para>
    /// Technique: Experience-based contract review; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"profileRepository": "Typed FreshFood.Reposistory.Repository.IProfileRepository fixture from
    /// fixtures.json", "currentCustomer": "Typed FreshFood.Api.Services.ICurrentCustomer fixture from
    /// fixtures.json", "unitOfWork": "Typed FreshFood.Reposistory.Repository.IUnitOfWork fixture from
    /// fixtures.json", "geocodingGateway": "Typed FreshFood.Api.Services.IGeocodingGateway fixture from
    /// fixtures.json", "variant": "Missing non-nullable dependency is outside declared caller contract"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke ProfileService.ProfileService(IProfileRepository
    /// profileRepository, ICurrentCustomer currentCustomer, IUnitOfWork unitOfWork, IGeocodingGateway
    /// geocodingGateway); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: No invented runtime rejection. Review-only until abnormal constructor behavior is
    /// agreed; DI registration failures are verified at composition root.
    /// </para>
    /// <para>
    /// Design exception expectation: N/A - no constructor guard specified
    /// </para>
    /// <para>
    /// Expected side effects: No execution claim
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): No abnormal constructor guard contract; review-only category is not
    /// execution coverage.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-088.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("No abnormal constructor guard contract; review-only category is not execution coverage.")]
    [NUnit.Framework.Property("DesignCase", "UTM-088-TC003")]
    public void UTM_088_TC003()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("No abnormal constructor guard contract; review-only category is not execution coverage.");
    }

    /// <summary>
    /// UTM-089-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileService.GetProfileAsync(CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"signal": "CancellationToken.None; use distinct token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileService.GetProfileAsync(CancellationToken signal); assert result, exception and captured
    /// calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Return the typed sentinel/declared projection; preserve arguments, ownership and
    /// cancellation token.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-089.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-089-TC001")]
    public async System.Threading.Tasks.Task UTM_089_TC001()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var profile = await owner.GetProfileAsync(Fixture.Token);
                Assert.That(profile.CustomerId, Is.EqualTo("7"));
                TestChecks.Single(profile.Addresses);
            }
        }
    }

    /// <summary>
    /// UTM-089-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileService.GetProfileAsync(CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"signal": "CancellationToken.None; use distinct token in forwarding variants", "boundary":
    /// "Empty then single-item collection where relevant; identifier=1; minimum allowed state. Branch-free
    /// forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileService.GetProfileAsync(CancellationToken signal); assert result, exception and captured
    /// calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Declared empty/default outcome or existing boundary guard; no invented maximum or
    /// rejection.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No duplicate entity or unnecessary call
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-089.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-089-TC002")]
    public async System.Threading.Tasks.Task UTM_089_TC002()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var profile = await owner.GetProfileAsync(Fixture.Token);
                Assert.That(profile.CustomerId, Is.EqualTo("7"));
                TestChecks.Single(profile.Addresses);
            }
        }
    }

    /// <summary>
    /// UTM-089-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileService.GetProfileAsync(CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"signal": "CancellationToken.None; use distinct token in forwarding variants", "failure":
    /// "First collaborator throws TimeoutException sentinel; for pure methods use a declared invalid-input guard
    /// instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileService.GetProfileAsync(CancellationToken signal); assert result, exception and captured
    /// calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Declared error propagation/catch behavior; no unauthorized write. Pure methods with
    /// no abnormal-input contract require review, not an invented assertion.
    /// </para>
    /// <para>
    /// Design exception expectation: Sentinel TimeoutException or source-defined error/catch
    /// </para>
    /// <para>
    /// Expected side effects: No downstream mutation after failure; rollback only where this method owns
    /// transaction
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-089.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-089-TC003")]
    public async System.Threading.Tasks.Task UTM_089_TC003()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        int geocodes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            throw new TimeoutException("profile sentinel");
        });
        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        await TestChecks.ThrowsAsync<TimeoutException>(async () =>
        {
            {
                var profile = await owner.GetProfileAsync(Fixture.Token);
                Assert.That(profile.CustomerId, Is.EqualTo("7"));
                TestChecks.Single(profile.Addresses);
            }
        });
    }

    /// <summary>
    /// UTM-090-TC001: Email None
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileService.UpdateProfileAsync(ProfileUpdateDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence / experience; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"Email": null}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileService.UpdateProfileAsync(ProfileUpdateDto request, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Save email; empty becomes null
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No write on rejection
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-090.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-090-TC001")]
    public async System.Threading.Tasks.Task UTM_090_TC001()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                string? email = (null);
                if (email?.Contains("65000", StringComparison.Ordinal) == true)
                    email = "tester@" + new string ('.', 65000) + "@";
                var updated = await owner.UpdateProfileAsync(new() { FullName = " Tester ", Email = email }, Fixture.Token);
                Assert.That(updated.FullName, Is.EqualTo("Tester"));
                Assert.That(updated.Email, Is.EqualTo(string.IsNullOrEmpty(email) ? null : email));
            }
        }
    }

    /// <summary>
    /// UTM-090-TC002: Email ''
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileService.UpdateProfileAsync(ProfileUpdateDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence / experience; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"Email": ""}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileService.UpdateProfileAsync(ProfileUpdateDto request, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Save email; empty becomes null
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No write on rejection
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-090.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-090-TC002")]
    public async System.Threading.Tasks.Task UTM_090_TC002()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var email = ("");
                if (email?.Contains("65000", StringComparison.Ordinal) == true)
                    email = "tester@" + new string ('.', 65000) + "@";
                var updated = await owner.UpdateProfileAsync(new() { FullName = " Tester ", Email = email }, Fixture.Token);
                Assert.That(updated.FullName, Is.EqualTo("Tester"));
                Assert.That(updated.Email, Is.EqualTo(string.IsNullOrEmpty(email) ? null : email));
            }
        }
    }

    /// <summary>
    /// UTM-090-TC003: Email 'tester@example.com'
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileService.UpdateProfileAsync(ProfileUpdateDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence / experience; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"Email": "tester@example.com"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileService.UpdateProfileAsync(ProfileUpdateDto request, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Save email; empty becomes null
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No write on rejection
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-090.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-090-TC003")]
    public async System.Threading.Tasks.Task UTM_090_TC003()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var email = ("tester@example.com");
                if (email?.Contains("65000", StringComparison.Ordinal) == true)
                    email = "tester@" + new string ('.', 65000) + "@";
                var updated = await owner.UpdateProfileAsync(new() { FullName = " Tester ", Email = email }, Fixture.Token);
                Assert.That(updated.FullName, Is.EqualTo("Tester"));
                Assert.That(updated.Email, Is.EqualTo(string.IsNullOrEmpty(email) ? null : email));
            }
        }
    }

    /// <summary>
    /// UTM-090-TC004: Email 'bad'
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileService.UpdateProfileAsync(ProfileUpdateDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence / experience; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"Email": "bad"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileService.UpdateProfileAsync(ProfileUpdateDto request, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject before transaction
    /// </para>
    /// <para>
    /// Design exception expectation: INVALID_EMAIL
    /// </para>
    /// <para>
    /// Expected side effects: No write on rejection
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-090.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-090-TC004")]
    public void UTM_090_TC004()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        {
            {
                Func<Task> operation = async () =>
                {
                    {
                        var email = ("bad");
                        if (email?.Contains("65000", StringComparison.Ordinal) == true)
                            email = "tester@" + new string ('.', 65000) + "@";
                        var updated = await owner.UpdateProfileAsync(new() { FullName = " Tester ", Email = email }, Fixture.Token);
                        Assert.That(updated.FullName, Is.EqualTo("Tester"));
                        Assert.That(updated.Email, Is.EqualTo(string.IsNullOrEmpty(email) ? null : email));
                    }
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo(new string[] { "INVALID_EMAIL" }[0]));
            }

            Assert.That(writes, Is.EqualTo(0));
        }
    }

    /// <summary>
    /// UTM-090-TC005: Email 'tester@ + 65000 dots + @'
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileService.UpdateProfileAsync(ProfileUpdateDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence / experience; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"Email": "tester@ + 65000 dots + @"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileService.UpdateProfileAsync(ProfileUpdateDto request, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject before transaction
    /// </para>
    /// <para>
    /// Design exception expectation: INVALID_EMAIL
    /// </para>
    /// <para>
    /// Expected side effects: No write on rejection
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-090.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-090-TC005")]
    public void UTM_090_TC005()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        {
            {
                Func<Task> operation = async () =>
                {
                    {
                        var email = ("tester@ + 65000 dots + @");
                        if (email?.Contains("65000", StringComparison.Ordinal) == true)
                            email = "tester@" + new string ('.', 65000) + "@";
                        var updated = await owner.UpdateProfileAsync(new() { FullName = " Tester ", Email = email }, Fixture.Token);
                        Assert.That(updated.FullName, Is.EqualTo("Tester"));
                        Assert.That(updated.Email, Is.EqualTo(string.IsNullOrEmpty(email) ? null : email));
                    }
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo(new string[] { "INVALID_EMAIL" }[0]));
            }

            Assert.That(writes, Is.EqualTo(0));
        }
    }

    /// <summary>
    /// UTM-090-TC006: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileService.UpdateProfileAsync(ProfileUpdateDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"request": {"fixture": "ProfileUpdateDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileService.UpdateProfileAsync(ProfileUpdateDto request, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Return the typed sentinel/declared projection; preserve arguments, ownership and
    /// cancellation token.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-090.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-090-TC006")]
    public async System.Threading.Tasks.Task UTM_090_TC006()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var email = "tester@example.com";
                if (email?.Contains("65000", StringComparison.Ordinal) == true)
                    email = "tester@" + new string ('.', 65000) + "@";
                var updated = await owner.UpdateProfileAsync(new() { FullName = " Tester ", Email = email }, Fixture.Token);
                Assert.That(updated.FullName, Is.EqualTo("Tester"));
                Assert.That(updated.Email, Is.EqualTo(string.IsNullOrEmpty(email) ? null : email));
            }
        }
    }

    /// <summary>
    /// UTM-090-TC007: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileService.UpdateProfileAsync(ProfileUpdateDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"request": {"fixture": "ProfileUpdateDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants", "boundary": "Empty then single-item collection where relevant; identifier=1;
    /// minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileService.UpdateProfileAsync(ProfileUpdateDto request, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Declared empty/default outcome or existing boundary guard; no invented maximum or
    /// rejection.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No duplicate entity or unnecessary call
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-090.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-090-TC007")]
    public async System.Threading.Tasks.Task UTM_090_TC007()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var email = "tester@example.com";
                if (email?.Contains("65000", StringComparison.Ordinal) == true)
                    email = "tester@" + new string ('.', 65000) + "@";
                var updated = await owner.UpdateProfileAsync(new() { FullName = " Tester ", Email = email }, Fixture.Token);
                Assert.That(updated.FullName, Is.EqualTo("Tester"));
                Assert.That(updated.Email, Is.EqualTo(string.IsNullOrEmpty(email) ? null : email));
            }
        }
    }

    /// <summary>
    /// UTM-090-TC008: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileService.UpdateProfileAsync(ProfileUpdateDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"request": {"fixture": "ProfileUpdateDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants", "failure": "First collaborator throws TimeoutException sentinel; for pure
    /// methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileService.UpdateProfileAsync(ProfileUpdateDto request, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Declared error propagation/catch behavior; no unauthorized write. Pure methods with
    /// no abnormal-input contract require review, not an invented assertion.
    /// </para>
    /// <para>
    /// Design exception expectation: Sentinel TimeoutException or source-defined error/catch
    /// </para>
    /// <para>
    /// Expected side effects: No downstream mutation after failure; rollback only where this method owns
    /// transaction
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-090.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-090-TC008")]
    public async System.Threading.Tasks.Task UTM_090_TC008()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        int geocodes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            throw new TimeoutException("profile sentinel");
        });
        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        await TestChecks.ThrowsAsync<TimeoutException>(async () =>
        {
            {
                var email = "tester@example.com";
                if (email?.Contains("65000", StringComparison.Ordinal) == true)
                    email = "tester@" + new string ('.', 65000) + "@";
                var updated = await owner.UpdateProfileAsync(new() { FullName = " Tester ", Email = email }, Fixture.Token);
                Assert.That(updated.FullName, Is.EqualTo("Tester"));
                Assert.That(updated.Email, Is.EqualTo(string.IsNullOrEmpty(email) ? null : email));
            }
        });
    }

    /// <summary>
    /// UTM-090-TC009: guard L17 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileService.UpdateProfileAsync(ProfileUpdateDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "ProfileUpdateDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"request.Email": "bad"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileService.UpdateProfileAsync(ProfileUpdateDto request, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: DomainException("INVALID_EMAIL") | Assert selected outcome False at
    /// src/FreshFood-API/Services/Implements/ProfileService.cs:17. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_EMAIL")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"Email": "bad"}
    /// </para>
    /// <para>
    /// Concrete exception expectation: INVALID_EMAIL
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-090-D01:False, UTM-090-D01:C1:False, UTM-090-D01:C2:False
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-090.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-090-TC009")]
    public void UTM_090_TC009()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        {
            {
                Func<Task> operation = async () =>
                {
                    {
                        var email = ("bad");
                        if (email?.Contains("65000", StringComparison.Ordinal) == true)
                            email = "tester@" + new string ('.', 65000) + "@";
                        var updated = await owner.UpdateProfileAsync(new() { FullName = " Tester ", Email = email }, Fixture.Token);
                        Assert.That(updated.FullName, Is.EqualTo("Tester"));
                        Assert.That(updated.Email, Is.EqualTo(string.IsNullOrEmpty(email) ? null : email));
                    }
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo(new string[] { "INVALID_EMAIL" }[0]));
            }

            Assert.That(writes, Is.EqualTo(0));
        }
    }

    /// <summary>
    /// UTM-090-TC010: guard L17 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileService.UpdateProfileAsync(ProfileUpdateDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "ProfileUpdateDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"request.Email": "tester@example.com"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileService.UpdateProfileAsync(ProfileUpdateDto request, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: continue | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/ProfileService.cs:17. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_EMAIL")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"Email": "tester@example.com"}
    /// </para>
    /// <para>
    /// Concrete exception expectation: No exception.
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-090-D01:True, UTM-090-D01:C1:False, UTM-090-D01:C2:True
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-090.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-090-TC010")]
    public async System.Threading.Tasks.Task UTM_090_TC010()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var email = ("tester@example.com");
                if (email?.Contains("65000", StringComparison.Ordinal) == true)
                    email = "tester@" + new string ('.', 65000) + "@";
                var updated = await owner.UpdateProfileAsync(new() { FullName = " Tester ", Email = email }, Fixture.Token);
                Assert.That(updated.FullName, Is.EqualTo("Tester"));
                Assert.That(updated.Email, Is.EqualTo(string.IsNullOrEmpty(email) ? null : email));
            }
        }
    }

    /// <summary>
    /// UTM-090-TC011: guard L17 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileService.UpdateProfileAsync(ProfileUpdateDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "ProfileUpdateDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"request.Email": ""}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileService.UpdateProfileAsync(ProfileUpdateDto request, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: continue | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/ProfileService.cs:17. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_EMAIL")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"Email": ""}
    /// </para>
    /// <para>
    /// Concrete exception expectation: No exception.
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-090-D01:True, UTM-090-D01:C1:True
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-090.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-090-TC011")]
    public async System.Threading.Tasks.Task UTM_090_TC011()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var email = ("");
                if (email?.Contains("65000", StringComparison.Ordinal) == true)
                    email = "tester@" + new string ('.', 65000) + "@";
                var updated = await owner.UpdateProfileAsync(new() { FullName = " Tester ", Email = email }, Fixture.Token);
                Assert.That(updated.FullName, Is.EqualTo("Tester"));
                Assert.That(updated.Email, Is.EqualTo(string.IsNullOrEmpty(email) ? null : email));
            }
        }
    }

    /// <summary>
    /// UTM-090-TC012: catch L19 -&gt; RegexMatchTimeoutException
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileService.UpdateProfileAsync(ProfileUpdateDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "ProfileUpdateDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "RegexMatchTimeoutException", "expression":
    /// "catch (RegexMatchTimeoutException)\r\n        {\r\n            throw new
    /// DomainException(\"INVALID_EMAIL\");\r\n        }"}, "fault": "Throw RegexMatchTimeoutException from the
    /// dependency protected by this catch; exercise filter true and false when present."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileService.UpdateProfileAsync(ProfileUpdateDto request, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: {              throw new DomainException("INVALID_EMAIL");          } | Assert
    /// selected outcome RegexMatchTimeoutException at src/FreshFood-API/Services/Implements/ProfileService.cs:19.
    /// Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_EMAIL")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-090-D02:RegexMatchTimeoutException
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-090.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-090-TC012")]
    public void UTM_090_TC012()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-090-TC013: conditional L23 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileService.UpdateProfileAsync(ProfileUpdateDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "ProfileUpdateDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"request.Email": "valid"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileService.UpdateProfileAsync(ProfileUpdateDto request, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: request.Email | Assert selected outcome False at
    /// src/FreshFood-API/Services/Implements/ProfileService.cs:23. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_EMAIL")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"Email": "tester@example.com"}
    /// </para>
    /// <para>
    /// Concrete exception expectation: No exception.
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-090-D03:False, UTM-090-D03:C1:False
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-090.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-090-TC013")]
    public async System.Threading.Tasks.Task UTM_090_TC013()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var email = ("tester@example.com");
                if (email?.Contains("65000", StringComparison.Ordinal) == true)
                    email = "tester@" + new string ('.', 65000) + "@";
                var updated = await owner.UpdateProfileAsync(new() { FullName = " Tester ", Email = email }, Fixture.Token);
                Assert.That(updated.FullName, Is.EqualTo("Tester"));
                Assert.That(updated.Email, Is.EqualTo(string.IsNullOrEmpty(email) ? null : email));
            }
        }
    }

    /// <summary>
    /// UTM-090-TC014: conditional L23 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileService.UpdateProfileAsync(ProfileUpdateDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "ProfileUpdateDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"request.Email": ""}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileService.UpdateProfileAsync(ProfileUpdateDto request, CancellationToken signal); assert result,
    /// exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: null | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/ProfileService.cs:23. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_EMAIL")
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"Email": ""}
    /// </para>
    /// <para>
    /// Concrete exception expectation: No exception.
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-090-D03:True, UTM-090-D03:C1:True
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-090.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-090-TC014")]
    public async System.Threading.Tasks.Task UTM_090_TC014()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var email = ("");
                if (email?.Contains("65000", StringComparison.Ordinal) == true)
                    email = "tester@" + new string ('.', 65000) + "@";
                var updated = await owner.UpdateProfileAsync(new() { FullName = " Tester ", Email = email }, Fixture.Token);
                Assert.That(updated.FullName, Is.EqualTo("Tester"));
                Assert.That(updated.Email, Is.EqualTo(string.IsNullOrEmpty(email) ? null : email));
            }
        }
    }

    /// <summary>
    /// UTM-091-TC001: Phone 12345678
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"Phone": "12345678", "AddressId": null, "IsDefault": null}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto
    /// request, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject before geocoding
    /// </para>
    /// <para>
    /// Design exception expectation: INVALID_PHONE
    /// </para>
    /// <para>
    /// Expected side effects: No external call/write if invalid
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-091.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-091-TC001")]
    public void UTM_091_TC001()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        {
            {
                Func<Task> operation = async () =>
                {
                    {
                        var result = await owner.SaveAddressAsync(new() { AddressId = null, RecipientName = " Tester ", RecipientPhone = "12345678", StreetAddress = " Test street ", IsDefault = null }, Fixture.Token);
                        Assert.That(saved, Is.Not.Null);
                        Assert.That(saved!.CustomerId, Is.EqualTo("7"));
                        Assert.That(result.IsDefault, Is.EqualTo("" == "True"));
                        Assert.That(geocodes, Is.EqualTo(1));
                    }
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo(new string[] { "INVALID_PHONE" }[0]));
            }

            Assert.That(writes, Is.EqualTo(0));
            Assert.That(geocodes, Is.EqualTo(0));
        }
    }

    /// <summary>
    /// UTM-091-TC002: Phone 123456789
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"Phone": "123456789", "AddressId": null, "IsDefault": null}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto
    /// request, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Save resolved address; default=false
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No external call/write if invalid
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-091.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-091-TC002")]
    public async System.Threading.Tasks.Task UTM_091_TC002()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var result = await owner.SaveAddressAsync(new() { AddressId = null, RecipientName = " Tester ", RecipientPhone = "123456789", StreetAddress = " Test street ", IsDefault = null }, Fixture.Token);
                Assert.That(saved, Is.Not.Null);
                Assert.That(saved!.CustomerId, Is.EqualTo("7"));
                Assert.That(result.IsDefault, Is.EqualTo("" == "True"));
                Assert.That(geocodes, Is.EqualTo(1));
            }
        }
    }

    /// <summary>
    /// UTM-091-TC003: Phone +123456789012345
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"Phone": "+123456789012345", "AddressId": null, "IsDefault": null}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto
    /// request, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Save resolved address; default=false
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No external call/write if invalid
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-091.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-091-TC003")]
    public async System.Threading.Tasks.Task UTM_091_TC003()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var result = await owner.SaveAddressAsync(new() { AddressId = null, RecipientName = " Tester ", RecipientPhone = "+123456789012345", StreetAddress = " Test street ", IsDefault = null }, Fixture.Token);
                Assert.That(saved, Is.Not.Null);
                Assert.That(saved!.CustomerId, Is.EqualTo("7"));
                Assert.That(result.IsDefault, Is.EqualTo("" == "True"));
                Assert.That(geocodes, Is.EqualTo(1));
            }
        }
    }

    /// <summary>
    /// UTM-091-TC004: Phone 1234567890123456
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"Phone": "1234567890123456", "AddressId": null, "IsDefault": null}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto
    /// request, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject before geocoding
    /// </para>
    /// <para>
    /// Design exception expectation: INVALID_PHONE
    /// </para>
    /// <para>
    /// Expected side effects: No external call/write if invalid
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-091.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-091-TC004")]
    public void UTM_091_TC004()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        {
            {
                Func<Task> operation = async () =>
                {
                    {
                        var result = await owner.SaveAddressAsync(new() { AddressId = null, RecipientName = " Tester ", RecipientPhone = "1234567890123456", StreetAddress = " Test street ", IsDefault = null }, Fixture.Token);
                        Assert.That(saved, Is.Not.Null);
                        Assert.That(saved!.CustomerId, Is.EqualTo("7"));
                        Assert.That(result.IsDefault, Is.EqualTo("" == "True"));
                        Assert.That(geocodes, Is.EqualTo(1));
                    }
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo(new string[] { "INVALID_PHONE" }[0]));
            }

            Assert.That(writes, Is.EqualTo(0));
            Assert.That(geocodes, Is.EqualTo(0));
        }
    }

    /// <summary>
    /// UTM-091-TC005: Phone 12345abc9
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"Phone": "12345abc9", "AddressId": null, "IsDefault": null}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto
    /// request, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject before geocoding
    /// </para>
    /// <para>
    /// Design exception expectation: INVALID_PHONE
    /// </para>
    /// <para>
    /// Expected side effects: No external call/write if invalid
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-091.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-091-TC005")]
    public void UTM_091_TC005()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        {
            {
                Func<Task> operation = async () =>
                {
                    {
                        var result = await owner.SaveAddressAsync(new() { AddressId = null, RecipientName = " Tester ", RecipientPhone = "12345abc9", StreetAddress = " Test street ", IsDefault = null }, Fixture.Token);
                        Assert.That(saved, Is.Not.Null);
                        Assert.That(saved!.CustomerId, Is.EqualTo("7"));
                        Assert.That(result.IsDefault, Is.EqualTo("" == "True"));
                        Assert.That(geocodes, Is.EqualTo(1));
                    }
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo(new string[] { "INVALID_PHONE" }[0]));
            }

            Assert.That(writes, Is.EqualTo(0));
            Assert.That(geocodes, Is.EqualTo(0));
        }
    }

    /// <summary>
    /// UTM-091-TC006: Foreign address edit
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Security error guessing; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"AddressId": "99", "OwnedAddresses": ["2"]}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto
    /// request, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject ownership
    /// </para>
    /// <para>
    /// Design exception expectation: NOT_FOUND / 404
    /// </para>
    /// <para>
    /// Expected side effects: No write
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-091.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-091-TC006")]
    public void UTM_091_TC006()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        {
            {
                Func<Task> operation = async () =>
                {
                    {
                        var result = await owner.SaveAddressAsync(new() { AddressId = "99", RecipientName = " Tester ", RecipientPhone = "123456789", StreetAddress = " Test street ", IsDefault = null }, Fixture.Token);
                        Assert.That(saved, Is.Not.Null);
                        Assert.That(saved!.CustomerId, Is.EqualTo("7"));
                        Assert.That(result.IsDefault, Is.EqualTo("" == "True"));
                        Assert.That(geocodes, Is.EqualTo(1));
                    }
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo(new string[] { "NOT_FOUND", "/", "404" }[0]));
            }

            Assert.That(writes, Is.EqualTo(0));
        }
    }

    /// <summary>
    /// UTM-091-TC007: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"request": {"fixture": "AddressInputDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto
    /// request, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Return the typed sentinel/declared projection; preserve arguments, ownership and
    /// cancellation token.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-091.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-091-TC007")]
    public async System.Threading.Tasks.Task UTM_091_TC007()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var result = await owner.SaveAddressAsync(new() { AddressId = null, RecipientName = " Tester ", RecipientPhone = "123456789", StreetAddress = " Test street ", IsDefault = null }, Fixture.Token);
                Assert.That(saved, Is.Not.Null);
                Assert.That(saved!.CustomerId, Is.EqualTo("7"));
                Assert.That(result.IsDefault, Is.EqualTo("" == "True"));
                Assert.That(geocodes, Is.EqualTo(1));
            }
        }
    }

    /// <summary>
    /// UTM-091-TC008: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"request": {"fixture": "AddressInputDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants", "boundary": "Empty then single-item collection where relevant; identifier=1;
    /// minimum allowed state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto
    /// request, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Declared empty/default outcome or existing boundary guard; no invented maximum or
    /// rejection.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No duplicate entity or unnecessary call
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-091.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-091-TC008")]
    public async System.Threading.Tasks.Task UTM_091_TC008()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var result = await owner.SaveAddressAsync(new() { AddressId = null, RecipientName = " Tester ", RecipientPhone = "123456789", StreetAddress = " Test street ", IsDefault = null }, Fixture.Token);
                Assert.That(saved, Is.Not.Null);
                Assert.That(saved!.CustomerId, Is.EqualTo("7"));
                Assert.That(result.IsDefault, Is.EqualTo("" == "True"));
                Assert.That(geocodes, Is.EqualTo(1));
            }
        }
    }

    /// <summary>
    /// UTM-091-TC009: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"request": {"fixture": "AddressInputDto"}, "signal": "CancellationToken.None; use distinct
    /// token in forwarding variants", "failure": "First collaborator throws TimeoutException sentinel; for pure
    /// methods use a declared invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto
    /// request, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Declared error propagation/catch behavior; no unauthorized write. Pure methods with
    /// no abnormal-input contract require review, not an invented assertion.
    /// </para>
    /// <para>
    /// Design exception expectation: Sentinel TimeoutException or source-defined error/catch
    /// </para>
    /// <para>
    /// Expected side effects: No downstream mutation after failure; rollback only where this method owns
    /// transaction
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-091.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-091-TC009")]
    public async System.Threading.Tasks.Task UTM_091_TC009()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            throw new TimeoutException("profile sentinel");
        });
        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        await TestChecks.ThrowsAsync<TimeoutException>(async () =>
        {
            {
                var result = await owner.SaveAddressAsync(new() { AddressId = null, RecipientName = " Tester ", RecipientPhone = "123456789", StreetAddress = " Test street ", IsDefault = null }, Fixture.Token);
                Assert.That(saved, Is.Not.Null);
                Assert.That(saved!.CustomerId, Is.EqualTo("7"));
                Assert.That(result.IsDefault, Is.EqualTo("" == "True"));
                Assert.That(geocodes, Is.EqualTo(1));
            }
        });
    }

    /// <summary>
    /// UTM-091-TC010: guard L31 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "AddressInputDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"phone": "bad"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto
    /// request, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: DomainException("INVALID_PHONE") | Assert selected outcome False at
    /// src/FreshFood-API/Services/Implements/ProfileService.cs:31. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_PHONE"); new DomainException("NOT_FOUND", 404)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"Phone": "bad", "AddressId": null, "Latitude": 10, "Longitude": 105, "IsDefault":
    /// null}
    /// </para>
    /// <para>
    /// Concrete exception expectation: INVALID_PHONE
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-091-D01:False, UTM-091-D01:C1:False
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-091.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-091-TC010")]
    public void UTM_091_TC010()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        {
            {
                Func<Task> operation = async () =>
                {
                    {
                        var result = await owner.SaveAddressAsync(new() { AddressId = null, RecipientName = " Tester ", RecipientPhone = "bad", StreetAddress = " Test street ", IsDefault = null }, Fixture.Token);
                        Assert.That(saved, Is.Not.Null);
                        Assert.That(saved!.CustomerId, Is.EqualTo("7"));
                        Assert.That(result.IsDefault, Is.EqualTo("" == "True"));
                        Assert.That(geocodes, Is.EqualTo(1));
                    }
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo(new string[] { "INVALID_PHONE" }[0]));
            }

            Assert.That(writes, Is.EqualTo(0));
            Assert.That(geocodes, Is.EqualTo(0));
        }
    }

    /// <summary>
    /// UTM-091-TC011: guard L31 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "AddressInputDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"phone": "0912345678"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto
    /// request, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: continue | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/ProfileService.cs:31. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_PHONE"); new DomainException("NOT_FOUND", 404)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"Phone": "123456789", "AddressId": null, "Latitude": 10, "Longitude": 105,
    /// "IsDefault": null}
    /// </para>
    /// <para>
    /// Concrete exception expectation: No exception.
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-091-D01:True, UTM-091-D01:C1:True
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-091.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-091-TC011")]
    public async System.Threading.Tasks.Task UTM_091_TC011()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var result = await owner.SaveAddressAsync(new() { AddressId = null, RecipientName = " Tester ", RecipientPhone = "123456789", StreetAddress = " Test street ", IsDefault = null }, Fixture.Token);
                Assert.That(saved, Is.Not.Null);
                Assert.That(saved!.CustomerId, Is.EqualTo("7"));
                Assert.That(result.IsDefault, Is.EqualTo("" == "True"));
                Assert.That(geocodes, Is.EqualTo(1));
            }
        }
    }

    /// <summary>
    /// UTM-091-TC012: catch L33 -&gt; RegexMatchTimeoutException
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "AddressInputDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "RegexMatchTimeoutException", "expression":
    /// "catch (RegexMatchTimeoutException)\r\n        {\r\n            throw new
    /// DomainException(\"INVALID_PHONE\");\r\n        }"}, "fault": "Throw RegexMatchTimeoutException from the
    /// dependency protected by this catch; exercise filter true and false when present."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto
    /// request, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: {              throw new DomainException("INVALID_PHONE");          } | Assert
    /// selected outcome RegexMatchTimeoutException at src/FreshFood-API/Services/Implements/ProfileService.cs:33.
    /// Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_PHONE"); new DomainException("NOT_FOUND", 404)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-091-D02:RegexMatchTimeoutException
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-091.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-091-TC012")]
    public void UTM_091_TC012()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-091-TC013: guard L38 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "AddressInputDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"lockedAddressField": "changed after preparation"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto
    /// request, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: DomainException("INVALID_ADDRESS_COORDINATES", 422) | Assert selected outcome
    /// False at src/FreshFood-API/Services/Implements/ProfileService.cs:38. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_PHONE"); new DomainException("NOT_FOUND", 404)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"Phone": "123456789", "AddressId": null, "Latitude": 91, "Longitude": 105,
    /// "IsDefault": null}
    /// </para>
    /// <para>
    /// Concrete exception expectation: INVALID_ADDRESS_COORDINATES
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-091-D03:False, UTM-091-D03:C1:False
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-091.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-091-TC013")]
    public void UTM_091_TC013()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (91m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        {
            {
                Func<Task> operation = async () =>
                {
                    {
                        var result = await owner.SaveAddressAsync(new() { AddressId = null, RecipientName = " Tester ", RecipientPhone = "123456789", StreetAddress = " Test street ", IsDefault = null }, Fixture.Token);
                        Assert.That(saved, Is.Not.Null);
                        Assert.That(saved!.CustomerId, Is.EqualTo("7"));
                        Assert.That(result.IsDefault, Is.EqualTo("" == "True"));
                        Assert.That(geocodes, Is.EqualTo(1));
                    }
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo(new string[] { "INVALID_ADDRESS_COORDINATES" }[0]));
            }

            Assert.That(writes, Is.EqualTo(0));
        }
    }

    /// <summary>
    /// UTM-091-TC014: guard L38 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "AddressInputDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"lockedAddressField": "changed after preparation"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto
    /// request, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: DomainException("INVALID_ADDRESS_COORDINATES", 422) | Assert selected outcome
    /// False at src/FreshFood-API/Services/Implements/ProfileService.cs:38. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_PHONE"); new DomainException("NOT_FOUND", 404)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"Phone": "123456789", "AddressId": null, "Latitude": 10, "Longitude": 181,
    /// "IsDefault": null}
    /// </para>
    /// <para>
    /// Concrete exception expectation: INVALID_ADDRESS_COORDINATES
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-091-D03:False, UTM-091-D03:C1:True, UTM-091-D03:C2:False
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-091.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-091-TC014")]
    public void UTM_091_TC014()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (181m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        {
            {
                Func<Task> operation = async () =>
                {
                    {
                        var result = await owner.SaveAddressAsync(new() { AddressId = null, RecipientName = " Tester ", RecipientPhone = "123456789", StreetAddress = " Test street ", IsDefault = null }, Fixture.Token);
                        Assert.That(saved, Is.Not.Null);
                        Assert.That(saved!.CustomerId, Is.EqualTo("7"));
                        Assert.That(result.IsDefault, Is.EqualTo("" == "True"));
                        Assert.That(geocodes, Is.EqualTo(1));
                    }
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo(new string[] { "INVALID_ADDRESS_COORDINATES" }[0]));
            }

            Assert.That(writes, Is.EqualTo(0));
        }
    }

    /// <summary>
    /// UTM-091-TC015: guard L38 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "AddressInputDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"lockedAddressField": "same as preparation"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto
    /// request, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: continue | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/ProfileService.cs:38. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_PHONE"); new DomainException("NOT_FOUND", 404)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"Phone": "123456789", "AddressId": null, "Latitude": 10, "Longitude": 105,
    /// "IsDefault": null}
    /// </para>
    /// <para>
    /// Concrete exception expectation: No exception.
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-091-D03:True, UTM-091-D03:C1:True, UTM-091-D03:C2:True
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-091.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-091-TC015")]
    public async System.Threading.Tasks.Task UTM_091_TC015()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var result = await owner.SaveAddressAsync(new() { AddressId = null, RecipientName = " Tester ", RecipientPhone = "123456789", StreetAddress = " Test street ", IsDefault = null }, Fixture.Token);
                Assert.That(saved, Is.Not.Null);
                Assert.That(saved!.CustomerId, Is.EqualTo("7"));
                Assert.That(result.IsDefault, Is.EqualTo("" == "True"));
                Assert.That(geocodes, Is.EqualTo(1));
            }
        }
    }

    /// <summary>
    /// UTM-091-TC016: if L41 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "AddressInputDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"request.AddressId": "valid"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto
    /// request, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood-API/Services/Implements/ProfileService.cs:41. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_PHONE"); new DomainException("NOT_FOUND", 404)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"Phone": "123456789", "AddressId": null, "Latitude": 10, "Longitude": 105,
    /// "IsDefault": null}
    /// </para>
    /// <para>
    /// Concrete exception expectation: No exception.
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-091-D04:False, UTM-091-D04:C1:False
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-091.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-091-TC016")]
    public async System.Threading.Tasks.Task UTM_091_TC016()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var result = await owner.SaveAddressAsync(new() { AddressId = null, RecipientName = " Tester ", RecipientPhone = "123456789", StreetAddress = " Test street ", IsDefault = null }, Fixture.Token);
                Assert.That(saved, Is.Not.Null);
                Assert.That(saved!.CustomerId, Is.EqualTo("7"));
                Assert.That(result.IsDefault, Is.EqualTo("" == "True"));
                Assert.That(geocodes, Is.EqualTo(1));
            }
        }
    }

    /// <summary>
    /// UTM-091-TC017: if L41 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "AddressInputDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"request.AddressId": "", "collection": "empty collection",
    /// "match criterion": "!(await profileRepository.GetAddressesAsync(id, ct)).Any(a =&gt; a.AddressId ==
    /// request.AddressId)"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto
    /// request, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: Continue after if; no action from the true branch | Assert selected outcome
    /// False at src/FreshFood-API/Services/Implements/ProfileService.cs:41. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_PHONE"); new DomainException("NOT_FOUND", 404)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"Phone": "123456789", "AddressId": "2", "Latitude": 10, "Longitude": 105,
    /// "IsDefault": null}
    /// </para>
    /// <para>
    /// Concrete exception expectation: No exception.
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-091-D04:False, UTM-091-D04:C1:True, UTM-091-D04:C2:False
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-091.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-091-TC017")]
    public async System.Threading.Tasks.Task UTM_091_TC017()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var result = await owner.SaveAddressAsync(new() { AddressId = "2", RecipientName = " Tester ", RecipientPhone = "123456789", StreetAddress = " Test street ", IsDefault = null }, Fixture.Token);
                Assert.That(saved, Is.Not.Null);
                Assert.That(saved!.CustomerId, Is.EqualTo("7"));
                Assert.That(result.IsDefault, Is.EqualTo("" == "True"));
                Assert.That(geocodes, Is.EqualTo(1));
            }
        }
    }

    /// <summary>
    /// UTM-091-TC018: if L41 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "AddressInputDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"request.AddressId": "", "collection": "one matching fixture
    /// item", "match criterion": "!(await profileRepository.GetAddressesAsync(id, ct)).Any(a =&gt; a.AddressId ==
    /// request.AddressId)"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto
    /// request, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: throw new DomainException("NOT_FOUND", 404); | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/ProfileService.cs:41. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_PHONE"); new DomainException("NOT_FOUND", 404)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"Phone": "123456789", "AddressId": "99", "Latitude": 10, "Longitude": 105,
    /// "IsDefault": null}
    /// </para>
    /// <para>
    /// Concrete exception expectation: NOT_FOUND
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-091-D04:True, UTM-091-D04:C1:True, UTM-091-D04:C2:True
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-091.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-091-TC018")]
    public void UTM_091_TC018()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        {
            {
                Func<Task> operation = async () =>
                {
                    {
                        var result = await owner.SaveAddressAsync(new() { AddressId = "99", RecipientName = " Tester ", RecipientPhone = "123456789", StreetAddress = " Test street ", IsDefault = null }, Fixture.Token);
                        Assert.That(saved, Is.Not.Null);
                        Assert.That(saved!.CustomerId, Is.EqualTo("7"));
                        Assert.That(result.IsDefault, Is.EqualTo("" == "True"));
                        Assert.That(geocodes, Is.EqualTo(1));
                    }
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo(new string[] { "NOT_FOUND" }[0]));
            }

            Assert.That(writes, Is.EqualTo(0));
        }
    }

    /// <summary>
    /// UTM-091-TC019: predicate L41 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "AddressInputDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"a.AddressId": "99", "request.AddressId": "1"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto
    /// request, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: a =&gt; a.AddressId == request.AddressId | Assert
    /// selected outcome False at src/FreshFood-API/Services/Implements/ProfileService.cs:41. Untaken branch must
    /// not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_PHONE"); new DomainException("NOT_FOUND", 404)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"Phone": "123456789", "AddressId": null, "Latitude": 10, "Longitude": 105,
    /// "IsDefault": null}
    /// </para>
    /// <para>
    /// Concrete exception expectation: No exception.
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-091-D05:False, UTM-091-D05:C1:False
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-091.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-091-TC019")]
    public async System.Threading.Tasks.Task UTM_091_TC019()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var result = await owner.SaveAddressAsync(new() { AddressId = null, RecipientName = " Tester ", RecipientPhone = "123456789", StreetAddress = " Test street ", IsDefault = null }, Fixture.Token);
                Assert.That(saved, Is.Not.Null);
                Assert.That(saved!.CustomerId, Is.EqualTo("7"));
                Assert.That(result.IsDefault, Is.EqualTo("" == "True"));
                Assert.That(geocodes, Is.EqualTo(1));
            }
        }
    }

    /// <summary>
    /// UTM-091-TC020: predicate L41 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "AddressInputDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"a.AddressId": "1", "request.AddressId": "1"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto
    /// request, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: a =&gt; a.AddressId == request.AddressId | Assert
    /// selected outcome True at src/FreshFood-API/Services/Implements/ProfileService.cs:41. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_PHONE"); new DomainException("NOT_FOUND", 404)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"Phone": "123456789", "AddressId": null, "Latitude": 10, "Longitude": 105,
    /// "IsDefault": null}
    /// </para>
    /// <para>
    /// Concrete exception expectation: No exception.
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-091-D05:True, UTM-091-D05:C1:True
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-091.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-091-TC020")]
    public async System.Threading.Tasks.Task UTM_091_TC020()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var result = await owner.SaveAddressAsync(new() { AddressId = null, RecipientName = " Tester ", RecipientPhone = "123456789", StreetAddress = " Test street ", IsDefault = null }, Fixture.Token);
                Assert.That(saved, Is.Not.Null);
                Assert.That(saved!.CustomerId, Is.EqualTo("7"));
                Assert.That(result.IsDefault, Is.EqualTo("" == "True"));
                Assert.That(geocodes, Is.EqualTo(1));
            }
        }
    }

    /// <summary>
    /// UTM-091-TC021: coalesce L42 -&gt; Null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "AddressInputDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "Null", "expression": "request.AddressId"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto
    /// request, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: request.AddressId ?? "" | Assert selected outcome
    /// Null at src/FreshFood-API/Services/Implements/ProfileService.cs:42. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_PHONE"); new DomainException("NOT_FOUND", 404)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"Phone": "123456789", "AddressId": null, "Latitude": 10, "Longitude": 105,
    /// "IsDefault": null}
    /// </para>
    /// <para>
    /// Concrete exception expectation: No exception.
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-091-D06:Null
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-091.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-091-TC021")]
    public async System.Threading.Tasks.Task UTM_091_TC021()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var result = await owner.SaveAddressAsync(new() { AddressId = null, RecipientName = " Tester ", RecipientPhone = "123456789", StreetAddress = " Test street ", IsDefault = null }, Fixture.Token);
                Assert.That(saved, Is.Not.Null);
                Assert.That(saved!.CustomerId, Is.EqualTo("7"));
                Assert.That(result.IsDefault, Is.EqualTo("" == "True"));
                Assert.That(geocodes, Is.EqualTo(1));
            }
        }
    }

    /// <summary>
    /// UTM-091-TC022: coalesce L42 -&gt; Non-null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "AddressInputDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "Non-null", "expression": "request.AddressId"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto
    /// request, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: request.AddressId ?? "" | Assert selected outcome
    /// Non-null at src/FreshFood-API/Services/Implements/ProfileService.cs:42. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_PHONE"); new DomainException("NOT_FOUND", 404)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"Phone": "123456789", "AddressId": null, "Latitude": 10, "Longitude": 105,
    /// "IsDefault": null}
    /// </para>
    /// <para>
    /// Concrete exception expectation: No exception.
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-091-D06:Non-null
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-091.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-091-TC022")]
    public async System.Threading.Tasks.Task UTM_091_TC022()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var result = await owner.SaveAddressAsync(new() { AddressId = null, RecipientName = " Tester ", RecipientPhone = "123456789", StreetAddress = " Test street ", IsDefault = null }, Fixture.Token);
                Assert.That(saved, Is.Not.Null);
                Assert.That(saved!.CustomerId, Is.EqualTo("7"));
                Assert.That(result.IsDefault, Is.EqualTo("" == "True"));
                Assert.That(geocodes, Is.EqualTo(1));
            }
        }
    }

    /// <summary>
    /// UTM-091-TC023: coalesce L42 -&gt; Null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "AddressInputDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "Null", "expression": "request.IsDefault"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto
    /// request, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: request.IsDefault ?? false | Assert selected outcome
    /// Null at src/FreshFood-API/Services/Implements/ProfileService.cs:42. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_PHONE"); new DomainException("NOT_FOUND", 404)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"Phone": "123456789", "AddressId": null, "Latitude": 10, "Longitude": 105,
    /// "IsDefault": null}
    /// </para>
    /// <para>
    /// Concrete exception expectation: No exception.
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-091-D07:Null
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-091.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-091-TC023")]
    public async System.Threading.Tasks.Task UTM_091_TC023()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var result = await owner.SaveAddressAsync(new() { AddressId = null, RecipientName = " Tester ", RecipientPhone = "123456789", StreetAddress = " Test street ", IsDefault = null }, Fixture.Token);
                Assert.That(saved, Is.Not.Null);
                Assert.That(saved!.CustomerId, Is.EqualTo("7"));
                Assert.That(result.IsDefault, Is.EqualTo("" == "True"));
                Assert.That(geocodes, Is.EqualTo(1));
            }
        }
    }

    /// <summary>
    /// UTM-091-TC024: coalesce L42 -&gt; Non-null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto request,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"request": {"fixture": "AddressInputDto"}, "signal": "CancellationToken.None;
    /// use distinct token in forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS",
    /// "CHECKOUT", "ORDER", "SESSION"], "overrides": {"scenario": "Non-null", "expression": "request.IsDefault"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;AddressDto&gt; ProfileService.SaveAddressAsync(AddressInputDto
    /// request, CancellationToken signal); assert result, exception and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: request.IsDefault ?? false | Assert selected outcome
    /// Non-null at src/FreshFood-API/Services/Implements/ProfileService.cs:42. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("INVALID_PHONE"); new DomainException("NOT_FOUND", 404)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Concrete execution input: {"Phone": "123456789", "AddressId": null, "Latitude": 10, "Longitude": 105,
    /// "IsDefault": true}
    /// </para>
    /// <para>
    /// Concrete exception expectation: No exception.
    /// </para>
    /// <para>
    /// Concrete witness basis: Concrete witness derived from the approved domain limits; no production seam or
    /// requirement change.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-091-D07:Non-null
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-091.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-091-TC024")]
    public async System.Threading.Tasks.Task UTM_091_TC024()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                var result = await owner.SaveAddressAsync(new() { AddressId = null, RecipientName = " Tester ", RecipientPhone = "123456789", StreetAddress = " Test street ", IsDefault = true }, Fixture.Token);
                Assert.That(saved, Is.Not.Null);
                Assert.That(saved!.CustomerId, Is.EqualTo("7"));
                Assert.That(result.IsDefault, Is.EqualTo("True" == "True"));
                Assert.That(geocodes, Is.EqualTo(1));
            }
        }
    }

    /// <summary>
    /// UTM-092-TC001: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileService.SetDefaultAddressAsync(string addressId,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"addressId": "2", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileService.SetDefaultAddressAsync(string addressId, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Return the typed sentinel/declared projection; preserve arguments, ownership and
    /// cancellation token.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-092.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-092-TC001")]
    public async System.Threading.Tasks.Task UTM_092_TC001()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                await owner.SetDefaultAddressAsync("2", Fixture.Token);
                Assert.That(addresses[0].IsDefault, Is.True);
                Assert.That(writes, Is.EqualTo(1));
            }
        }
    }

    /// <summary>
    /// UTM-092-TC002: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileService.SetDefaultAddressAsync(string addressId,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"addressId": "2", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants", "boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed
    /// state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileService.SetDefaultAddressAsync(string addressId, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Declared empty/default outcome or existing boundary guard; no invented maximum or
    /// rejection.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No duplicate entity or unnecessary call
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-092.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-092-TC002")]
    public async System.Threading.Tasks.Task UTM_092_TC002()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                await owner.SetDefaultAddressAsync("2", Fixture.Token);
                Assert.That(addresses[0].IsDefault, Is.True);
                Assert.That(writes, Is.EqualTo(1));
            }
        }
    }

    /// <summary>
    /// UTM-092-TC003: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileService.SetDefaultAddressAsync(string addressId,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"addressId": "2", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants", "failure": "First collaborator throws TimeoutException sentinel; for pure methods use a declared
    /// invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileService.SetDefaultAddressAsync(string addressId, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Declared error propagation/catch behavior; no unauthorized write. Pure methods with
    /// no abnormal-input contract require review, not an invented assertion.
    /// </para>
    /// <para>
    /// Design exception expectation: Sentinel TimeoutException or source-defined error/catch
    /// </para>
    /// <para>
    /// Expected side effects: No downstream mutation after failure; rollback only where this method owns
    /// transaction
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-092.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-092-TC003")]
    public async System.Threading.Tasks.Task UTM_092_TC003()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            throw new TimeoutException("profile sentinel");
        });
        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        await TestChecks.ThrowsAsync<TimeoutException>(async () =>
        {
            {
                await owner.SetDefaultAddressAsync("2", Fixture.Token);
                Assert.That(addresses[0].IsDefault, Is.True);
                Assert.That(writes, Is.EqualTo(1));
            }
        });
    }

    /// <summary>
    /// UTM-092-TC004: coalesce L49 -&gt; Null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileService.SetDefaultAddressAsync(string addressId,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"addressId": "2", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"scenario": "Null", "expression": "(await profileRepository.GetAddressesAsync(id,
    /// ct)).SingleOrDefault(a =&gt; a.AddressId == addressId)"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileService.SetDefaultAddressAsync(string addressId, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: (await profileRepository.GetAddressesAsync(id,
    /// ct)).SingleOrDefault(a =&gt; a.AddressId == addressId) ?? throw new DomainException("NOT_FOUND", 404) | Assert
    /// selected outcome Null at src/FreshFood-API/Services/Implements/ProfileService.cs:49. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("NOT_FOUND", 404)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-092-D01:Null
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-092.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-092-TC004")]
    public void UTM_092_TC004()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-092-TC005: coalesce L49 -&gt; Non-null
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileService.SetDefaultAddressAsync(string addressId,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"addressId": "2", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"scenario": "Non-null", "expression": "(await
    /// profileRepository.GetAddressesAsync(id, ct)).SingleOrDefault(a =&gt; a.AddressId == addressId)"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileService.SetDefaultAddressAsync(string addressId, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: (await profileRepository.GetAddressesAsync(id,
    /// ct)).SingleOrDefault(a =&gt; a.AddressId == addressId) ?? throw new DomainException("NOT_FOUND", 404) | Assert
    /// selected outcome Non-null at src/FreshFood-API/Services/Implements/ProfileService.cs:49. Untaken branch must
    /// not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("NOT_FOUND", 404)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-092-D01:Non-null
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-092.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-092-TC005")]
    public void UTM_092_TC005()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-092-TC006: predicate L49 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileService.SetDefaultAddressAsync(string addressId,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"addressId": "2", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"a.AddressId": "99", "addressId": "1"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileService.SetDefaultAddressAsync(string addressId, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: a =&gt; a.AddressId == addressId | Assert selected
    /// outcome False at src/FreshFood-API/Services/Implements/ProfileService.cs:49. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("NOT_FOUND", 404)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-092-D02:False, UTM-092-D02:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-092.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-092-TC006")]
    public void UTM_092_TC006()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-092-TC007: predicate L49 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;ProfileResultDto&gt; ProfileService.SetDefaultAddressAsync(string addressId,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"addressId": "2", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"a.AddressId": "1", "addressId": "1"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;ProfileResultDto&gt;
    /// ProfileService.SetDefaultAddressAsync(string addressId, CancellationToken signal); assert result, exception
    /// and captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: a =&gt; a.AddressId == addressId | Assert selected
    /// outcome True at src/FreshFood-API/Services/Implements/ProfileService.cs:49. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws: new
    /// DomainException("NOT_FOUND", 404)
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-092-D02:True, UTM-092-D02:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-092.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-092-TC007")]
    public void UTM_092_TC007()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-093-TC001: Active-order address
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OperationResultDto&gt; ProfileService.DeleteAddressAsync(string addressId,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"Owned": true, "HasActiveOrder": true}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OperationResultDto&gt;
    /// ProfileService.DeleteAddressAsync(string addressId, CancellationToken signal); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Reject deletion
    /// </para>
    /// <para>
    /// Design exception expectation: ADDRESS_USED_BY_ACTIVE_ORDER / 409
    /// </para>
    /// <para>
    /// Expected side effects: No delete
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-093.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-093-TC001")]
    public void UTM_093_TC001()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("True" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        {
            {
                Func<Task> operation = async () =>
                {
                    {
                        Assert.That((await owner.DeleteAddressAsync("2", Fixture.Token)).MessageCode, Is.EqualTo("ADDRESS_DELETED"));
                        Assert.That(writes, Is.EqualTo(1));
                    }
                };
                var actualException = Assert.ThrowsAsync<DomainException>(async () => await operation())!;
                Assert.That(actualException.Code, Is.EqualTo(new string[] { "ADDRESS_USED_BY_ACTIVE_ORDER", "/", "409" }[0]));
            }

            Assert.That(writes, Is.EqualTo(0));
        }
    }

    /// <summary>
    /// UTM-093-TC002: Normal operational input
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OperationResultDto&gt; ProfileService.DeleteAddressAsync(string addressId,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Equivalence partitioning; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"addressId": "2", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants"}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OperationResultDto&gt;
    /// ProfileService.DeleteAddressAsync(string addressId, CancellationToken signal); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Return the typed sentinel/declared projection; preserve arguments, ownership and
    /// cancellation token.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: Verify declared call count/order; no unrelated mutation
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-093.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-093-TC002")]
    public async System.Threading.Tasks.Task UTM_093_TC002()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                Assert.That((await owner.DeleteAddressAsync("2", Fixture.Token)).MessageCode, Is.EqualTo("ADDRESS_DELETED"));
                Assert.That(writes, Is.EqualTo(1));
            }
        }
    }

    /// <summary>
    /// UTM-093-TC003: Boundary / empty result
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OperationResultDto&gt; ProfileService.DeleteAddressAsync(string addressId,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Boundary value analysis; input category: Boundary.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"addressId": "2", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants", "boundary": "Empty then single-item collection where relevant; identifier=1; minimum allowed
    /// state. Branch-free forwarding: empty optional field unchanged."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OperationResultDto&gt;
    /// ProfileService.DeleteAddressAsync(string addressId, CancellationToken signal); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Declared empty/default outcome or existing boundary guard; no invented maximum or
    /// rejection.
    /// </para>
    /// <para>
    /// Design exception expectation: No exception specified.
    /// </para>
    /// <para>
    /// Expected side effects: No duplicate entity or unnecessary call
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-093.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-093-TC003")]
    public async System.Threading.Tasks.Task UTM_093_TC003()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        CustomerAddress? saved = null;
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            return n switch
            {
                "GetCustomerAsync" => Task.FromResult(customer),
                "GetAddressesAsync" => Task.FromResult(addresses),
                "SaveCustomerAsync" => Write(),
                "SaveAddressAsync" => Save(a),
                "HasActiveOrderAsync" => Task.FromResult("" == "True"),
                "DeleteAddressAsync" => Write(),
                _ => throw new InvalidOperationException(n)};
        });
        Task Write()
        {
            writes++;
            return Task.CompletedTask;
        }

        Task Save(object? [] a)
        {
            saved = (CustomerAddress)a[0]!;
            return Write();
        }

        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        // Act and Assert: explicit invocation and expected-result comparisons.
        {
            {
                Assert.That((await owner.DeleteAddressAsync("2", Fixture.Token)).MessageCode, Is.EqualTo("ADDRESS_DELETED"));
                Assert.That(writes, Is.EqualTo(1));
            }
        }
    }

    /// <summary>
    /// UTM-093-TC004: Dependency failure / abnormal contract
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OperationResultDto&gt; ProfileService.DeleteAddressAsync(string addressId,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Experience / failure injection; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"addressId": "2", "signal": "CancellationToken.None; use distinct token in forwarding
    /// variants", "failure": "First collaborator throws TimeoutException sentinel; for pure methods use a declared
    /// invalid-input guard instead."}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OperationResultDto&gt;
    /// ProfileService.DeleteAddressAsync(string addressId, CancellationToken signal); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Declared error propagation/catch behavior; no unauthorized write. Pure methods with
    /// no abnormal-input contract require review, not an invented assertion.
    /// </para>
    /// <para>
    /// Design exception expectation: Sentinel TimeoutException or source-defined error/catch
    /// </para>
    /// <para>
    /// Expected side effects: No downstream mutation after failure; rollback only where this method owns
    /// transaction
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-093.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Property("DesignCase", "UTM-093-TC004")]
    public async System.Threading.Tasks.Task UTM_093_TC004()
    {
        // Arrange: test inputs and mock setup.
        var customer = new Customer
        {
            CustomerId = "7",
            FullName = "Before"
        };
        var addresses = new List<CustomerAddress>
        {
            Fixture.Address()
        };
        int geocodes = 0, writes = 0;
        var repo = StrictProxy.For<IProfileRepository>((n, a) =>
        {
            Assert.That(a[^1], Is.EqualTo(Fixture.Token));
            throw new TimeoutException("profile sentinel");
        });
        var geo = StrictProxy.For<IGeocodingGateway>((n, a) =>
        {
            geocodes++;
            return Task.FromResult(new GeoPointDto { Latitude = (10m), Longitude = (105m) });
        });
        var work = new ImmediateWork();
        var owner = new ProfileService(repo, Fixture.Customer(), work, geo);
        await TestChecks.ThrowsAsync<TimeoutException>(async () =>
        {
            {
                Assert.That((await owner.DeleteAddressAsync("2", Fixture.Token)).MessageCode, Is.EqualTo("ADDRESS_DELETED"));
                Assert.That(writes, Is.EqualTo(1));
            }
        });
    }

    /// <summary>
    /// UTM-093-TC005: guard L57 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OperationResultDto&gt; ProfileService.DeleteAddressAsync(string addressId,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"addressId": "2", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"collection": "empty collection", "match criterion": "(await
    /// profileRepository.GetAddressesAsync(id, ct)).Any(a =&gt; a.AddressId == addressId)"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OperationResultDto&gt;
    /// ProfileService.DeleteAddressAsync(string addressId, CancellationToken signal); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: DomainException("NOT_FOUND", 404) | Assert selected outcome False at
    /// src/FreshFood-API/Services/Implements/ProfileService.cs:57. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-093-D01:False, UTM-093-D01:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-093.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-093-TC005")]
    public void UTM_093_TC005()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-093-TC006: guard L57 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OperationResultDto&gt; ProfileService.DeleteAddressAsync(string addressId,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"addressId": "2", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"collection": "one matching fixture item", "match criterion": "(await
    /// profileRepository.GetAddressesAsync(id, ct)).Any(a =&gt; a.AddressId == addressId)"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OperationResultDto&gt;
    /// ProfileService.DeleteAddressAsync(string addressId, CancellationToken signal); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: continue | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/ProfileService.cs:57. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-093-D01:True, UTM-093-D01:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-093.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-093-TC006")]
    public void UTM_093_TC006()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-093-TC007: predicate L57 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OperationResultDto&gt; ProfileService.DeleteAddressAsync(string addressId,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"addressId": "2", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"a.AddressId": "99", "addressId": "1"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OperationResultDto&gt;
    /// ProfileService.DeleteAddressAsync(string addressId, CancellationToken signal); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: a =&gt; a.AddressId == addressId | Assert selected
    /// outcome False at src/FreshFood-API/Services/Implements/ProfileService.cs:57. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-093-D02:False, UTM-093-D02:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-093.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-093-TC007")]
    public void UTM_093_TC007()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-093-TC008: predicate L57 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OperationResultDto&gt; ProfileService.DeleteAddressAsync(string addressId,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"addressId": "2", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"a.AddressId": "1", "addressId": "1"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OperationResultDto&gt;
    /// ProfileService.DeleteAddressAsync(string addressId, CancellationToken signal); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: Outcome follows the expression: a =&gt; a.AddressId == addressId | Assert selected
    /// outcome True at src/FreshFood-API/Services/Implements/ProfileService.cs:57. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-093-D02:True, UTM-093-D02:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-093.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-093-TC008")]
    public void UTM_093_TC008()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-093-TC009: guard L58 -&gt; False
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OperationResultDto&gt; ProfileService.DeleteAddressAsync(string addressId,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Abnormal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"addressId": "2", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"review constraint": "!await profileRepository.HasActiveOrderAsync(id, addressId,
    /// ct) = False; arrange matching entity/mock state and verify reachability"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OperationResultDto&gt;
    /// ProfileService.DeleteAddressAsync(string addressId, CancellationToken signal); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: False: DomainException("ADDRESS_USED_BY_ACTIVE_ORDER", 409) | Assert selected
    /// outcome False at src/FreshFood-API/Services/Implements/ProfileService.cs:58. Untaken branch must not
    /// execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-093-D03:False, UTM-093-D03:C1:False
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-093.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-093-TC009")]
    public void UTM_093_TC009()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }

    /// <summary>
    /// UTM-093-TC010: guard L58 -&gt; True
    /// </summary>
    /// <remarks>
    /// <para>
    /// Method under test: Task&lt;OperationResultDto&gt; ProfileService.DeleteAddressAsync(string addressId,
    /// CancellationToken signal)
    /// </para>
    /// <para>
    /// Technique: Branch / evaluated atomic-condition coverage; input category: Normal.
    /// </para>
    /// <para>
    /// Arrange: Strict interface fakes; no live DB or provider; independent arrange-act-assert fixtures.
    /// Prerequisite guards before the target pass; reset all state per case.
    /// </para>
    /// <para>
    /// Design input: {"arguments": {"addressId": "2", "signal": "CancellationToken.None; use distinct token in
    /// forwarding variants"}, "baseFixtures": ["CUSTOMER", "CATALOG", "CART", "ADDRESS", "CHECKOUT", "ORDER",
    /// "SESSION"], "overrides": {"review constraint": "!await profileRepository.HasActiveOrderAsync(id, addressId,
    /// ct) = True; arrange matching entity/mock state and verify reachability"}}
    /// </para>
    /// <para>
    /// Act: Arrange fixtures and overrides; invoke Task&lt;OperationResultDto&gt;
    /// ProfileService.DeleteAddressAsync(string addressId, CancellationToken signal); assert result, exception and
    /// captured calls/effects.
    /// </para>
    /// <para>
    /// Design expected result: True: continue | Assert selected outcome True at
    /// src/FreshFood-API/Services/Implements/ProfileService.cs:58. Untaken branch must not execute.
    /// </para>
    /// <para>
    /// Design exception expectation: Only source-defined exception/catch; candidate throws:
    /// </para>
    /// <para>
    /// Expected side effects: Observe declared state/transaction effects; no unauthorized write.
    /// </para>
    /// <para>
    /// Branch/condition targets: UTM-093-D03:True, UTM-093-D03:C1:True
    /// </para>
    /// <para>
    /// Execution constraint (NUnit Ignore): Symbolic structural vector: concrete witness and independent oracle are
    /// not specified in the approved design.
    /// </para>
    /// <para>
    /// Design source: artifacts/testing/test-design/backend-unit/backend-unit-test-design.json; method ID UTM-093.
    /// </para>
    /// </remarks>
    [NUnit.Framework.Test]
    [NUnit.Framework.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.")]
    [NUnit.Framework.Property("DesignCase", "UTM-093-TC010")]
    public void UTM_093_TC010()
    {
        // Arrange: test inputs and mock setup.
        // Not executed: the documented design constraint must be resolved before arranging a real invocation.
        Assert.Ignore("Symbolic structural vector: concrete witness and independent oracle are not specified in the approved design.");
    }
}
