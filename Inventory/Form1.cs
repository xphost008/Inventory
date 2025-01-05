
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.VisualBasic;

namespace Inventory;
class SomeConst
{
    public const string Icon = """
                               AAABAAEAAAAAAAEAIABDeAAAFgAAAIlQTkcNChoKAAAADUlIRFIAAAEAAAABAAgGAAAAXHKoZgAAeApJREFUeNrt/XmMLVl+3wd+fufEcm/eXN9eVa+quru6m92tJps7KVELPR
                               p5IA0EmyNBopahLQmCYNqC7JFF2MAMDGMMyKCssQXbEjiCFhPWQlkypTFMYSzRoET1iHuTbLLZ7Ora33v11tzvFnHO+c0fJ+LmzXy5RES+ei9f1f0C2a8680bciBPx+55zfsv3
                               BwsssMACCyywwAILLLDAAgsssMACCyywwAILLLDAAgsssMACCyywwAILLLDAAgsssMACCyywwAILLLDAAgsssMACCyywwAILLLDABYU86wtY4Nngc5965dD//8rr7z7rS1rgGW
                               BBAB8xHDH8fvXvuP7Fggg+WlgQwEcERwx/HbgC/M3q//9J4CGwXX9gQQQfDSwI4EOOI4Y/AL4R+A+APwzY6vce+DHgvwO+DAzrAxZE8OHGggA+xPjOb/707L/3h5M/AHw38B+f
                               cdh/BfxMr5f9o/oXv/Tlrz/rW1ngA8KCAD6EmDd84PtH4+l3h6A/CKQNT1GKyF/N8/RngL9f/3JBBB8+LAjgQ4IjRg/wu4EfBH679+FaCIFp4RqdK0ksxgjGmPvAvwL+KvCT85
                               9ZkMGHAwsCeM7x7d/0KQBEBBGWgFeAvw68Crw8/9kQFOc8RXk8ESSJxVqDyGOvxXvAO8CfBt4FRvUfFkTwfGNBAM8pasOvsC4i10T4q8C3AJdOO1ZVmUwd3gcAjBHS1B5n+Eex
                               CXyJuLK4z1zUYEEEzycWBPAcYs74+8C3A39ChH9HogWf+kxV48/akpAlQgjK1Clbw4AROJsD0OrnfwD+FvALVHkECxJ4/rAggOcIR2b9PwR8G/BD87+sZ/HjDNkHWO0Ll5cNH7
                               uasNaPH9oeBd6673i459kZK9a0uqwfBn4R+Af1LxZE8PxgQQDPAY4x/N8J/Cmgd9IxIgdkoApZInzimmVjYLi2agghTuMQXwJj4N6OZ3M/8PV7jsJpk9VAjQnwN4B/yYIIniss
                               COCCYt6rPxyW9PvJ7wD+AvAdwI0m5xABI/DZl1JW+4arKyau3/XkzwvwYNezPQp85XYZtwzNL/su8PPAXwJ+ev4PCzK4mFgQwAXDkXDeMvAC8LeJHv2XVfVEA4ZorAawBj51FT
                               52CQa5YIxhQoqe8sir9QIDMyWEwHAaePOh8NX7glcIoZGPAGLU4D3g3wXeB/brPyyI4GJhQQAXBEcMf51o+P81MXtv7ejnjxJB/d/LOVwewLfehMRAYg/+pggeSynJY0RgCGRS
                               kuKQas4XAeehDPAL7woPhsLehNnfGmAH+BngPyISwXb9hwURXAwsCOAC4Fu/8ZMIkGdJ7nz4HuI+/88QJ/RTn1EISlC4tAQreTT8PDnbQAtSAgYRxeLpSXHq51Vh4uDn3hV2J/
                               BoKG2iBgL8CPAPnA9fzLNkKsDP/fLXnvXQf+SxIIBniG/9xk/O/9/vF+FbjMgPNYjHA9Grv9xTriwrH7+s3BgYaLBnV6CXBBKjGAn4IEy9NHoZjIEHQ8sbD4Xb28r2WEkaRg1E
                               BCPywyJ8ibkU4wURPDssCOAZ4Ijh/wHg3wT+GLFaDyNSZ/YdC1VILXzimme1r1xdVXyAVASLkMvxFqlAbgP9NJBXBICCV5g6w9QLxSlEoGJBDBiDFbi1rWzuK792x1O4k1cDdU
                               TCHHxgCPwd4H8DZkVHCyJ4+lgQwFNCvce/tjHg9oNdEZHvAv4zYnnuS0c/LwAiWCNHfgefvhEN/9JynOuPOgUTEZIjRGCNspo7EqOk9nFHogAuCE5hODV4Pfje2vD1CLEYiaRy
                               b1d5tK/88nv+sSiDrfYJJ7xot4nlx/858LPMLV4WZPB0sCCADxhHnHsrqnrNB/1RYs7+zSbnMCJkqfDSRuDly4FeGpfd4ZS1vhANtC+Gy31PZpTEaKOQnlfwQdgtEoKcHjmg+h
                               4XYDhVXr8X+PqDQNCYlNhwN3OLWGPwA8QU4736Dwsi+GCxIIAPCEcMf40YxvuLwPeqshw0nB7Oq736PVjtK59/OWBNDO9pAyu2RsmSuNS3Ams2bg8SaR7XV2DsU8YuwashcPoL
                               U0cNXIBffCewNVJ2J/GYhkSwD/wU8J8Sw4g79R8WRPDBYEEAHwDmjD8hluX+fuDf54hXXzV68HXOopUYb19fUpZ78NmXAr2mVfxAYuNM30v9Y39LBZaNxC1CCyIA2HcZZTAUwT
                               b6vALjAn7lVmBnDI+GMcW4wQtXj9F/D/wvxDJkBwsS+CCwIIAniO/4pgPnnhjzR4iVeX/hrONCFdN3XlnuKTfW4MUNZWNZCeHs71WFNAkkBvLUn/pQFeiJkBvoG8HQbkUwdBku
                               GCbBNnp5rIEHe8q7m8qtLdidtK41+EvAl1T179W/+Plfeb3VCRY4GQsCeAKYN3zg3wL+bTHm+zgmgec4KJAa+KaXLf08sNIvZlV7Zx3XT4S1nqHUkqC+ydcdHGviSmDZNH8NBH
                               AqFMEy9ilFMGe+RCJgBd585Hg0Crxxz+IbENscdlT1x4F/DPyT+pcLIjg/FgTQEUeMPgG+APyXwGeonXtVOO8k1Ln3X3gl4fqqcHXVoKqUPjAqSqbueOEOIXrXrw0sqYU8EVwI
                               +KDslQWhiZOAg7V2JtAzwlJLIig1Rgv2yvxQ1OAoyuCZeF9teZStkbA9FL5+z55amwCHt0dEZ+FXgf8E+BWqrQEsyKArFgTQEvX+XuMUvQZcBn4U+Djw4rEHzRGBajT8PBE+ds
                               XwuZcs/VRI7IFXXwBfGcveZIIL8b9NNZNeHVh6iZAcY7BBlTIE9ssipgs3uKe6fsAIrBohrbYGTeFVcMGy6zJUpTJqxaOMypLAYUMWiUlMUye888Dw/rah9AdjA48Z/lHcAd4i
                               Rg0eqbJTk94ixbgdFgTQEEe8+quovqaq/3fg93LQYONEqAIirC/B+sDyXa+lj+Xqn3ScD57hdMJqz7CWm0YedQUmrmTiPS6Es3OKK9SKIhuJITUGtPlaXYGxSxn7hK3C4c5wYE
                               Sii2TwlduW/YmwNxHQxqXIY+CfBtX/QpU3gN36DwsiaIYFATTAnPEb4PcBvxvV/1BBUT11DJX4gl8ewEZf+cJLsDLIwAhizvaoJyZgRenZZoKex2FYlrgQKMLpPoKah/pJQpok
                               rKYpwRWo96CeNq/Lg4lh4mHfVQIlDY4ZF8Lrdw17E9gZCaZB1CD6T1VU+W+IEYOfAAIsSKAJFgRwCo7M+n+U6NX/88yPW73MPmYa9yEW6HzssnJzXbm+woHzSwSTpGAsYg4vuK
                               NTMJBIILP+iTwkVWXsHaUPTMPj51RV+mlKliQs5zlWZjWBqC9R7whlSdOYQT27bxbC2Al7ZSweOgvWwKN94f6u8P6WYVRw7HFRp+CxjEYF/jJRt/Dv1r9cEMHJWBDAMThi+L+P
                               aPy/l9PENo8QgTXwhReV9T68tF7H+x8/TEzMrTdJFlN/RcmsJ5E487eJ1Z+F6MFXyuAZu4MlemotK3lOliSk1p64/1bvUO8J5bTxdxqBqYeRE7YKYdyg6EiqKsMHu8L+RPjaXT
                               MLh55g+EexCfxTIgn8RP3LBRE8jgUBVJgv0FHVLLH2MyL8FeA1jshrn4Taq//5G4EXVpVLS9FxFxpYsTGGpVxIUoORdmZvK6MNTZIGqIkgEBTSJMEYIUuSsxxvB+MTPFqWBFc0
                               +nz9ndMARRDujg0+nL2WkOgOYHcsPNgTvn5XCBrHs+GL+x7whgh/LrH2q6o6u+BFUlHER54AjlTmrRO9+n8L+DRw3YhgTlm71p7rXiq8fMnwjS9bcguJUXwxraMFxx5bp8j2k7
                               hiMJUHToxBzkibkyqykCR2LsKglKWDs2fIQ+cxRrC2kSz4oRtXlDCdoME3y0+u4DSuCO5PDKGqRjwrxdgHKBy8ftdwf0eYusNRg+NgzKwC8R7wNeBPAI+YEyb5qBPBR5YAjhj+
                               MvBZ4P8G/F+ILbQOjY0xgswVt9R2vbEsrPaF734tITUSc/XnjouzZfEYEVgDmYniHSdBEoMcUd04zvCPIgTFe1ddY3PDtPbExiCnQjUQphMIAW0ZNdicRv/A1MvZtQZEsnAefu
                               09w/5U2B0frjWIq7BjSVuBEvifgf8X8BvMSZV9VIngI0kA9R7/uz53ky9++d3vA76H6Nw7E0aEoMKVFcOlZeEbb1pW+3J21p53BO9J1GEF+i3y+yMRGGxiMMaeuiKZRwgB70Pj
                               rUGNmlyMaZezOyO74CMZND0OeNgyaiDA/hTeuGfYHsHu2FTFUo1f6b8MfBH48foXH0US+EgRwBHn3h8BviOo/llVkiYzZdBouC9fUV5aN3z8aoaIOdv4FfIUMguplqAB17BPXw
                               1jDDa1mNRiji4zzoD3ISbm+GapwnEVYLAtkvZFhMI5xmWJuhINgYFtpjIEtV8Ctgth1DJq8GBP2NwTbm1ZJiWNjqvggP+WqGQ8qzX4KBHBh54Ajmma+XuIPe6+F7ha//K4yrx5
                               GIHPvBhY6cHV1bjHTqzFGsNyns2r3RxCYmApU1J7OOnHO48vPb5sQQQKploNpL209VI9hDBbFRwHaw3GmNYzf1BlZzym9D6mL1cCILkIqWlXa2AEJh4mXng0jVuDs1A7Xx/uxU
                               Si1+/aRo7XOTwgliH/deCfzf/hw04GH1oCOFKZ1yOm6v4I8DFO8eqrRkOpEvcQgdeuBa6vxbr847z6iTGk1rKcx1CeqV7I1V6sfEtOmLBVFQ1KOS0JrnkhD8QVgVhD1ksbF9vX
                               9wexSWi9NTDGkCSWFgIes5Dn9nhM4T3lMauLOsU4EVgyQs+0WxHMogYjg2+gdVg/m71JzCN4636sNWgZNXibKMj6FrHhCfDhJYIPHQEcKdJZB66KMT9ClN66ctbxWuXM9lO4NA
                               h8+oWANXpmyi5E/8AgT7iynNJPBduw5j5KfCvluECDtnLciQg2S0jSJDoMW6D+nrYrCR8Cw6JgfzptVHg0IwJjWE8MCbRyFnqFoRMeTCIRNI0alB5ev2t5tC9MSzkzajCHh0Sp
                               sj9DXB1s13/4sBHBh4YAjhj+EvDNxAf4xwAjp6lsUs38CpcGwkoPvv1VQ2rBqWfqPT6EU73U1iipDfTSgIiw3u+TWktubatknuA85bRsTQQIpHmGsSb6CJ4wBJhWM/32eNw8Z0
                               AVW62QVns98iRBQyAUddSgeYpxHTXYL2NCUZP6hlBFDb5y2zIqhN2xNFUoUmJK8d8hrhx/mbm26B8WIvhQEMAR4/+DwHdyghCH1Ov6ObgAG0twdVn4hhuG9f7jy/yJd/igj+XT
                               p1YxRukfo8BjRFjt9cisJU/TVgbtS4d3oZ2PoLq/JE8jESTtnIUnnW9alhTeszuZtCo1NkA/y+glCYMse+xS1DuCi2nGseioORE8nBimHvaaRg0E9ifC2w8N28NIBB2ESX4O+I
                               f1Lz4MJPBcE8DMwReX0H+YGM77M0B29p0LitBP4VPXDFdX4MU1OTNDbeo9ZQgESjIbdfdOm01UlSxJ6KUpgywjNaaVTbrSob5l1EBBbIwaJOnjtQZNICKUzjEsCibOUTjXaquw
                               nOek1jLIzn4UddRAy4Kmyc911GCnEPadMHQNUoyJfQ0e7glbQ+Gdh4apaxZtqFAQVwNfBH6s/uXzTATPHQEc49X/XuDPqepvRfV60/MYgW96SdhYEl7YOFuYokZioJd6VAJFKC
                               gaStuoKnmSkFjLer9/YtTg2GNDwI2GBDWV2m7TA7tFDULl3HOVV7+N4fdsQm4tg16ObUF2QZWt/T0SlEErX4YwdoaJFzYLpWzwOOqowWiSsTcWfuVWaNsE9R7wr4G/QowezPC8
                               kcFzQwBHDH9A1NL/m0R57ZlXX09IelGi0RuBT1+DVzeElTzGkQOCGDlxpqz3jMt55RCsPuZV8arsFdEZ1vQFSirfwFq/HzP7TvqgKn46Bg2z+1IVvJqzqpAfv4cqkSjJjyeCWs
                               RjZzxm6j2uYc5APT6JMSynMRxqq23WWRmLx32nEEVPBmdEDRTBBwN64AsoQuxjeH9ahXRPuNbcJmTWkhghBNibwDubga/d09gEtV3U4F3gTxJ7HAzrPzwvRHDhCeCYppnXickb
                               3w5sHHuQHjjQ6ll9kMPVZfjml+RUIQ6pcuJVKpUcQ9VJ52SRClWl1MB+URJUCWcq6UcYEVbynH6WkcyRj2pAiynBuxOXJTUR1AbQFCJCkiXYKmoQ9QoCoxZe/fnrNyKspBn2FP
                               kza81jtQYuBMZFwd4J31n3NajlzG2dgl0Z/mkEGBSGDrZKxYXoybMiJMawZJPHGpXMy5l/6b3Awz1lvyBupZpZyBbwC8CfJa4Otus/XHQiuNAEMGf8PeC7gD8O/Kkm1x6VdJTL
                               y8Jyqo2bZtazSZ4JaQJLebtrnnrPNHgK7wnajAgEWF9aYilN0bJoXG5bC3ROvJCKaaXwC0LeT3AoD0bNvfrz47SaZfRt0nzlU60Gxs6xPRo1P05gxQpGLaLtfCibhTLxQmaz01
                               db9X0pFB5+/p3AzjhEYRJpHDUA+BvA/0jsdDSBi00CF5IAjsz6fxj4VuCHmh4fvfrCC+uGT123rOce5/XMZJu6aWZqlOU87n2DJLEl1hlvgAizLDpjDHvTKaVzjMry9O9UpV85
                               B1fyHCoFHg2Okx6PVNc6DkqhMApKTwwp5sS+gIevVREUa2JJ8H5QSo3navNC9GxCag09m8yu6SwoMCpLnAamvrnYiQKZGLLqHtuRHYx9EtWM9WwV4yJEAdN7+55bm4ZHVYZhy6
                               jBDwO/xAV3Fl4oAjhi+H+Q2FTjB4hx/TNR59z/lpcSLi8LNzeqDLI6/baM2W9HiaBumtlLYuPMo0IckQAMwRxfumdtLNCZT6EVomNrVHnRR0VxaAmsquRpylKa0k9TkpkQh6Ah
                               Cm/EKsLHfRqjoJQaCeAocjEkGHrHEIEQQ5aCInOaA1HhF6aqjILiOhBBYgz9JGn0+Vr0dOo9U+8oQmhFBPEehb40a1Iy+06EIhiKYCiPEEH0IcQIT+E9gYMt4INdYWcsvPXAUr
                               rG2wKIeQM/SpQqu5Dhw2dOAJ/9ZFTQ3t0bcvveFt/5zZ/+HmJrqG/hJJXdY25CBL7l1Wj4N9biy39cPnidfusLRwjhzKaZh449QgTHGf5j1yaCqxJodqdTCudIjGGt3yc1hvQU
                               IY66qs4XE1BlEpRxgEL1xKSkg/RbQw9DVhGBNb4ap5NvUIBCo2rQrm/u1Ky/MzWWXhKjAE2fm9OAC8qwLPAttyGpGNIOROBU8CqMQkLQKKk+8W7m1D06rrXBb+7H/IHX79q2UY
                               M7RJmyv/hzv/y1L16/usH66gCA33zjVqt7ftJ4ZgRQG36FFVW9Zq390aV+/oqInNk0s37prIFXriR8+oZhY0lI7dkKPCKAKit5QMoxiYRWe+CgBkmyEz3qx34n0fEVVBGRVvkA
                               wXtG0yl7ZdnKSKwIG/0+qXcx465NIlK1ItiviKDp8t5WjsHlNCOpNBSafZ/iWsqZQ3wHlq0hx7YLkQJBhULh/kSj9DqnG4SR2DR1Uibc3kp496HDV07GM30LgKreGo2m7zrvf0
                               BEDjVBfVZE8NQJ4IjhrxGbaPww8DuAlTp0lKXJsTPrzKvfE9b7ht9yMyExUVcfYJApxjxeEjrTvq+q83ozh6BGnbticqp6Tyx+EXyoUnsr4Ym0F9Nv2+bhn4WakMrSHRiEKiPn
                               mFaz1XHXWIfk+mnKSq8XHV+qM9EO1dCKCBTY98pEY4isKYTY2nxlLjTYjESUiYuahUFP1hSwAqkIq1XJce2D8MG2jowEhX0H23NRg8dWAUQ/UGJ6CIIPggvKr99ybI8Dw0ldV3
                               HM+UNgWjhK5+vnugf8NNGvdYu5JqhPmwieKgHMGX8G/C7g+4B/jyNNM2vkWToLIUEs8FhfEpZ7hs+9lJCnx88v1kA/jZV4dUFOZiG1MMhPfjVCWVTClwdZd5G5hXBK7F0kEoFY
                               aV2rf/RhKGcLeSiwXxR4DRRzn8mThNQY1qv8gmOP9S7eZ0sZLwV2veI6OAsza+nbeG1tkoqGZUkZAmXwsyFNBRIRVs3JGXzzz6vto4hRAxj7+plEbQQjOXKMX0WBaal85bZjfx
                               LYHh30PnTe431gMj3WEVy/83+NKEryL4iZhk+VBJ4qAXzmtZcM8P3AF0SksVc/S1PWBpaXLmW8uGFZX5Izl/m10SfGsb5kWOs1t8tQTtEQop+A5kk3xhpsmmATizQtBeTA8EdF
                               QWZsY+GOoMrIlTHyIMJynpM03FoEV0KVi98UdfrtKChFSyJQoG8TlhPbqB/C/HGjMoqooIG+EbLGVZZRvSloS2UjYHOqjLzB08NIwlnfaAS2R8qdLc+tzYKdoacoyjYE9MMS25
                               39/a++caudhNM50Mxt+4Sw1O8Z4P8RVD8znTZTlI3GUTnuQkDV0KzJtGdSxoaZIsKktFxbaabDZdI8OnnEgfP4hrX6wQeCK/CpxRhDmqdnXqoAe9MphY/XmxlLZi29BlWEdRKO
                               VARgGi6zgdiTIEkRm6DBE8qzn0fc48OqFQoVSlWG4eytgRIbkWZ4TAiIBlQM2oAIBFhOU0ARDUjwzUuJq+YrJsRSYG2Ytj11VedkFUocpYLn7GsNqjgf8F5bZYYCOO9/SJWvAv
                               +AqrHJ08BTJYAsS6Fa5iSJpSwdRXHyDJSnSZxVjWHs4Ot3HQ92A4Nc+PzLGb308QpfJRDCNGbTVeO4PQIjnuHUs9q3XB6cTQQikOQJmliSEKJoR5MXSGJJb8ATvMdYS9o7/vvG
                               Zcn+dEpZlRuLCGPvKIJn4gyDND2UIXgclJj+HAAJAWOEpGE4DkCSFNEEsclsC3QWlLgUz0RIRU6NGqQCy1ZIiJ2Ioy/DI+pR9aix6Ble/FmDErFgTAxn+pOblERySVCpvAO2ih
                               QZiWXWJzzHqYupxC7UjzKQE0jEEzBMNOdowFIVJqXyq+8VDCfK9ig+gyxNsNYQfKA4paLT16XmcUnbXGf9CeGpEsChL67ktPIsZTIpcFX3WBEhsYY0TQ4VzAhxb783DuyNYXc8
                               YX3J8PmXMxIbi3RcmBwy/Nmx1Yu3P/WMy8CjoePGasYgM6eLSCpVjYAlswYNSjGeQkO13eADwQe8cyRZik3jrO5CYGs0wocwCzvVe+M6f6BQjysCVoSVLMfMfebEy1WNs08o51
                               R+GkAEsQnWVP0FpuNGzsKaCFIRMpFZ1KAe83VrZopAx0USRAPiFRWHmvTAYM+4VkXwSYZowHjHbDstEE47j6lqPqygLlQh4WjwY8exob3oPA4YAkviCVim5JQ+Co786rsFW6PA
                               aBqPnE8WsiZOXvVk5yptxpq055yCzwzPjADgQOK63++hGphMCrI0OTXRov7bqFAmhef+7oSXLwduXlL6eSzUOWlMRSrjcsqtrQnWCDfXc9LEkCenK/uKCMYK+aDHdFripmUMeX
                               H2flSDUk4KyqkwVBe782jgrNc91O20J2Mya1lK0lmY7bTvVFWC94y9m2Umptaena1XPQ/bXyI4jy8miDYLAlqBvgi5HCTY1A1OzqIRUTDqUYRg0tk9nA4BsThrCL6MXZVsQpPt
                               oYjgrSUEGE5jaLaJQzQRxQVHOfF8/aHwtQdCqMOHcvr3ZVlKEpTptGA8LZ654c/u6VlfANTae4Ysr2rHG7x0NdFqUN59ILz3UPjkjcDqElxeOVwIdByCQvDKW48m9FPD1ZWUfm
                               rJk8cdjPWznThH4T07kzEAPSwZMQ+/EVQZYAmijIgJN65B4ZBS1Rh4Tz9JZn6C4wx6toKoklum3h8oFBlzpjBJqJSInA9gM0Q9Ejxyxr77WIebCY9lHR69MzEWjMVmOVTjeFYU
                               pL7vqfcUVZszgEEaQ6DZCb6Fg74CwqgUnI8kEkuM3IlkVy8S7+wImyP4lTv1ZBE/e9YkUEu+ee/bZBE+FVwIAjgKrZfDc4NcQ478OztG4Wt3DGkCr14NrC3BtTUlNGhBNS4Dbz
                               +asta3LOeWjaUEa2oNOWFclhTOzSrXZoSgngnQx2IRetLMA28QViShFKXQwFQDvmEF4dg5xjiWkpTECL0jxThj5yg1MHFzoUxVNkcjUmMYZBm9qgnoPBHUrcVqCfGDZ2FRayMJ
                               EJ1w8wgqs7DbUfhgKhGOY4hADCZJog/iiMHWq5Z4LYdVjAVmLc9HRyIYw7JEEJbSmJqcmwNHqiqMnVB6YXpUPEQElXQWaRD1s++yBt7bFh4O4av3Ykei+V1j/d+1nsTR5++9j6
                               uElr0ZnhYuJAFExJJcIO7FKwM5SwzS+UgEyz24t628fEVZXTq7VZYR2J14dsfRWdhPLWtLhuF0ytQ5ymomPe77R+oxQEksVskarAgUSBBSsaQIHmWkvrHneOhKjAiFD+TWElCK
                               apVwXFJFnYm4PR6Tl2Vs/53nWDE472Yz/4nXayyKRcTE1YAPjQRKYnKOiQVIqlijmCyv2p+lnEbPsS+BwZjoJBsXxaza8qRKS0XZL0sSEabG0k8SSpdQBijOkA+rU71RgyGwue
                               /52gPh3p6wPY5+ppNcRnU6ek0E7oIbfo0LTAA1onNHkeb7UQOjKexNDJtDZSmH33LTkyanN42Q6n/2pgFrMvYmUTIqaDjVAVcvSSWxDHq9GD6aFo2iBnWVmzGeHoZiLv32jFGZ
                               tfyudQpnDsXTjhOZEUVdlzCwSeMEHRVbGQoE1zyrMCblRC+8cZD1zo6t14grAuhLxnQyRv3pq6W62Gg0DWyNPRqUfpI2kv4KClNn+IW3Y+ehzSEYDkRgzoL3YWb8zwOeAwI4QK
                               i8u0ZjRdtJ0OqzIlEjfm8KO68nbAyUz77oY9TgiCBI7Ylf6UUtOyNRHzAxfZQePowIWnucD2AqoYmNpSVsFY8HyGzeKGpgTUAkOgSjx1zoiTAMsfjnLAqp9/z1fzeFAGVVpDR1
                               jp5N6CdJQ6mySMomifvnUIY4Lg3eeVXBl46J89g0Icmbk09iLZeWBvgqilLXVhw+P7ggjAsbnYoaw3muLEgkViweXckZiR79wsMvvxd4sKeMSkDrFHM5PU1cIWigKD2zNvEt8a
                               x8gs8VAdQ4iQgUHovT1u/WtIR728L9nYRXrwZeWFdWelHvXzD00oR+lh1jRLGgJTEDFMWHIaoBYxRr7My5dvQlFonhpt5yH196XHEg9T1fj//4t0WP+ooVlq3M0m/Llum3rcaz
                               yigcu5JBGrUJzso/mF0sgsliBVbw4fiN8DFQVVxR4sqylZy5EcFYy9XlZcpqS+ODp3CKqjAq7KEU4HrM6tBqUXh6NiGzhtTENuWbI+WdTeX1+9FnNKsFmBvwWk16ngi0itIUZf
                               dwXhwuxbl2BWlPCs8lAdQIUnXs1WYVa/X+7K37hrcfwKdvBDYGwmde6MfznR4jq4hghaCOPAms9dPYDfiML7apJckS9odjXOkZ2HBmSK5eyq/bWLpai3Z8kESgwH4ZdQuWkxRr
                               DFnTqkUjGGPRoOBD/Lfhl5aTorWcuYiQJ5Yrg2V2xiWTwjMqQyMVpmlwFAH2Ril7Y+HLd/Sx1eBp36vE1m7lOZb6MRdA55OAngkuFAHUYoyt2tRzEDVoVdyi8Bt3DP1UGE4dN9
                               YML18yZ8qCAxhJKH0Uk0yt0s9Ofmnmm2aOXIHTQPBCKjHdtMkVW4lEMFVhGpRxUJq302gPVWW3LOJ2pAo7Ni1fFiNgLPVANk2/VY25EmKEJE0wiT2VCJTo5ym9UPqMQQ7GlDgf
                               GJ+iwmQN3NsRNveFdx4Gpo5YtizNOiSVZXSYthFNPbjHSqrOh2du+DUuDAEkBr75Y8ruGH7zXvMedYfQkgiMwNQpX3rbsTEQ3lg1fP5mwsbg7HbfEFNHp04oPSRWGRyRwPeq7I
                               5Gs312/YLtB8UCE4W+iU00z0J0FkJuhdxEBZ8mzsKuqB1p+2VJanx0FiZpYzlzqZfzVcO+xkQQlHJSYhIfsxmPkTMfFjGWPz2SYbuUpmgKWWIpnD9EBCKwOxbevCdsjYS9cSQD
                               UyWHSRU6MSc0kCpLFzM3G97HY/cF3NxQ+mngl968GMYPF4gArIFXNhRdh5cvKV+7J9zePrvq71i0JILEwu5Y2R55Hu0FVvrCb/tUSmqFJs11Jg6MEwoHvVTJk6irX/ooDjqf6g
                               uV444o6VUqWJRVa7DSTFgil1gRV6ffDjsSwVyU9dTPuBBmP4kYlo/1lZxwfKWoKUbQplsDOUijDiHM+hpMnDApBeePr9mvz9xLoux3P0vYHRcMC8+X3zUMp8Le5CC+/9ix1Z4e
                               kVmKuHOecq6RausxFrg8UG6uK0uZomibRiQfOC4MAUDM0sosXBnAyivK519Ufv4dw/4ExiW187k5RDB1AcgZZCASl9rbI2VnrPyvvzTlhQ3DN7+akqenKw3V+/lJqeyMS6auJE
                               8cxoQzw45ewQObLpCIsGZjnftp2WVHa+OXRNgLyrRB1CDea0xhXsmi5PFeMSVwdvqtCwGVwKQIDJKEYCyNnohQ+QgSksRQTpr3PnQuEDSwPfRgE9SmZ6r7ikAIQuEMv3474c62
                               MJ7qrDfEaZgVV3koXYz6tPHN1blrWRI1KT59PZBWWhSq0KbB09PAhSKAGkGZDdrv+lRgdwK/9G6My45LO8sxbwIh1unXbb9Pe6DxPY1OpHEJbz/wvPPA87mbCTcvWy4tx1n6KB
                               E4H0Ur9qfT2blLbzFiWMo8xvCY0Ohj90zU+nvglL4RlkysnjsrzbT2maxaQU+JGtSKSIkx9JKEnj149Jd6fSbeMXEuhtZ4/NiZEEetwBMcNriYuy8ScwNOgKkchLaadvOBJfhA
                               OTm+G3JNjEFhVNbjrRBKKEtMmoF5vOWZkXjcgz3l1qbn12/7maBLYmUWrjvp+dcpu65jkU5Q6CVKP4XXrsYZ/+hi9AJN/sAFJYB5GIGNPvz210q+/tDxYC9jc5hQeNOOCCRmls
                               WU18MvXfS4H/YeV7KBKPBr7zm+csvxhVdT1gfCy5ejKOTUxZTU4bQ4trlFUGF/mpCY2EMwsaHR8m9cOfoGJjoLew0Omo8aOI15BPNRg561sTFGcnxpcs9GUhi5EhfCLKOwrvYb
                               VIT02PMJcWkWTPIYEcQEHpkpOh06zhryQa9qglppLlRG70KMybsTljOhLOLqLknB1E1H4L3NwPZQ+eV33bGrtbjKq96BudyM+p0IIXRa6geFzCobPc+VJceVVRMdoc8BnioBdO
                               1HDzG+f3nguLrsuLubsj+13NrK2/R8n323tTJjexpKUgeFX3izZJAL964rV1aUlaWSwp39wrgglFNLlgjLeYLSrPHHMOhMsrtN1CCZixoUqmAS+kkzMZSaIMbOoRrI8eRnCo0o
                               JpQxGiMGk0SREttAHdimsUuRKxzDiVKWJUVoMFOqEsqCxBrubCfc2RPevB8YTvVM/X4Rma3kaq9+F8OvU65vrpYMssD1gasmjbN7Dxx7XR2OOS+eCQHMbrgLESjcWC3xWrLW92
                               yPEm5tN3dKzX/3oeSOBi+ANXFJ+svvOlb6ylofPnlDTtUZrNHPktgc1FiUFFWH18nZY8bhqMGSic6/JsdlEh2GKooGd2Jfg+OwlFSpumoJDaoBoZrxkwyxdlbZ1wTRq58yFdDE
                               Yo7oMp6E3Ql8+X1lc1iyNRYSI6frO8zhvF59gBeXS9Z7nvW+r4MdQHtDPqnA7WngmWwB5pdeM0NsgTpf4OpyyVrfcX214J3NnK1h0loamnkiCCfntoe5nENrYDgR9ifC7jjWGn
                               zjy57ExL/NZ6El1rKS53EpLHUjyxQkwWiG1wlBT1a3qc9znqhBrHALseZeLNqACGbJxWJRaxCNs/zj4xM9/CbrVx7/ZoavxOzMUSGHGnKKjXt7TWKbNJ2rPowRiaja87NvC7tT
                               YWdcKyHHs2rQg2d6DKJX33UOwxmB9X7g5mpJ33pSW28n2p+rgfzJB45n7gOol+KqUo1i8yEJColRVnqeb7g+pvTCb95dYuIM07JlyEAkzlyA+gPF3Og2lOM+jgD7E2E4hZ/+as
                               K1tcAnrwf6mVTL/d6hpplHXV0ilkSWqhTjUZTIOsWPf1zUYNXG5WwTYRJRRdRB8ARbtTxr2L1QRfA2OyACYrzcZL1YztuAxGf1+CHWaMwbztHyXBFBsjzeVTmlcMqkVL58R7i9
                               E3MAVE/w6qvOJpd6hReCMi0i0Xbx6ueJkifwySuO1EBiQkx/bmn49cfbyZR+cHjmBFAjhEA5KUn6sWttm1WBVkSQGOULN/fZn1reetRjVBgKnxzrvDoNUrXpOqtEFg7e+9LDnU
                               3DnS3hm15OeGHdkvTNoaXhCWeoUoyXUTw+jCsiOD3Xr44aPKyiBv3KYdisZ16tqScEmwDmIJvy9LutiCDHGoNYc2JL9XkYgYlTChfYn8aW3EkD/4AxUWTk/iTn/W3Pl9911dUf
                               Hvvjr5RZtp1zvlXX49kYz7z6yisbnkF2MBWoNm15MjsgvlNlSXux8g8OF4YA4EA6K+aD29hwo+X2QARWep5vvjnk/l7K1ihlc5RRto4aCMYcpG82CwvFsMGvvOv4tVuOb34lRg
                               1euWwbLRMFS2KWCVpWPwVN+s50iRrU12t87bxr1gS1hg8xnfW09mhGoPDK3sSzM3bsTaIijhFhkGUk1jwmTFI/QyPw7iPP5lD50jslPhwsmeWMxZ2qUvpA6QPOB6xpZ6x1GPra
                               oPLsD0K3hLR4MWgIaPDVFrPjeT4gXCgCqFFngZkkvlw2bX+ZQeHqSsnVlZL7e47h1HJnp0e7TUbtLDydCOSxxX30Kf78myXLPeH9rcArVywvrMdag7NgJMVIRtAEVd/IWQjRWW
                               iI/f2yFlGDuDUo53ofNkzwoVK19Yf7JNY+i3u7JeMysDN20Z0g9bNRdidTUmvIEk+/UvBRog/lzlbgnUeetx549ifRqz+ftah6MhFMqwawZQfnXv1uvLKhDHLl2nLAu+7Gr97F
                               PIfQvm7gaeFCEkCNKK8dtfu8diu+ALi+UuAHsN53bI5S7u7mrc91HBGcZV7WRPHSL99y3N7ybAwM3/KxlJVeE+NSjMQqI9GEoI5wBhHUGYnDoEwExgqDqpFGo3usJLGMBk7rhn
                               wcovSVIBLYGgdGZWB/6k8M04rEzMKyKCi9xxoDmvJLbzu2hoFHw6qz0wk7jKNEUJYxJ8Odx6u/plweKOv9+N3ed5uw1XlUqhn/guNCE0CN4D0JyoY1s640bR5M5Rjm0qBkuee4
                               sTrlnc0+u5MEH9puMaRSF6Zq33CGj4Dood4ZxVqDzf3A2pLht9a1BpZTM9PibOkqufOEPA2k9vTcBanueaIxK9ACazb6IxrdbQh4FRSPWDko7DkFMTEKRgWU3oAKRkJs6nLiWE
                               Yj23eeL7+njKcxDfvAq382nA+zXP0uxmoNrPWUj12JNRyVtEGnWb8WRjUSLpz450l4qgRQ7xO7JF3UufrLNubs7fnYyrnNmeqoQZp5Pn1tSOkNbzwcMC0No1LO3Fseuh6EUKlG
                               NJEqq8+9O4574n/8C4GPX7V87qWEpfyg1qBW+PGqVdOQeaEIYTy1TOZSjM0Z7b7rqMFDF8hEWDklaqAIPsy3QlPUxUo+SWK23dE3O5b/C3sTM5uVTbXPX81yXAiMXXmoU46RGA
                               mYTOHN+4Y727HAR7VZoUwdOSorIY42XXhmXv00Ovg+fT1ULeQqQZmGJzqUKl0Z/uG/dokLPn3WeCYrgJoIZtl4LVA7gtaqlNdRUDyKayGUEfeaSmIDv+3VKTsTy+sPE3YnhlEh
                               Z2aSPXa+SqGoKREAlF55/Z7j9XuOL7yScm3VcH1NKENgXLgTa9rr3Pb9aYI1Si/1UZ2oQZHLVJWpU5aM0DMxxVc4QdL7yMFaelSYEUHA4AKMpoI7YRUlQGoMaZYz9R6ncZn+cE
                               /YHMLrd80hJbGz3v+jht8WQaGXxg7Sr1xSVnuH1aRaPfN6XLR5m/cT8QyXC8+8McgB2kvdJBKJYKrR8VVXw7Vy8gEb/cB3v1Jwe8fycGi4vRsFP9o+ljqUZmgWNag/8qW3SxIL
                               n7+ZkCQF19d05m84DVH7LmUpFcSG2Muwwes4DMowwJXMYjE01bYQhVB4psFQqlIE2+jdFYFBanl30/D+XsnX7gret3vvvT+9V8BZ42wN3FhVNpaUayvt4/eHzhd0ZvznwgXYJz
                               xzH8CMBETYL5WNlv65mPIq5BI933X32rYICi+ueV5c81weBHYmhjcedinoqNpPUc1YDV5YkSig80tvOwa54cGu8sKGcmmgp5Yg95OERAyJGAgg4lDxICe3mFNiYVBWNeRQEYSY
                               1HJWrf6wjLP91Eul8+/j8acsmayBe7vKWw8Dt7aUvUlcYTV992td/fOk7L68EVjJ4dpqldzV1atfxXLPo91XBBtzPJ697QMXgAAOIOw5cChLVhi0vLJ5oYxU4opg3PJJ18/15l
                               qs6rKqbI5THo6aFdIcupsqm02rTLQmRGBNLEN+677waE8Y9JTPvBjopYcNZmb4R2PvmiCaVDF99xgR1Ko+iTGztGSo1HvisgU9Rup77ITCx6Ya82HUWiBzltI9RwSqMQLyi+8E
                               dibK5jBuU5pur4421GiyIjqKF9eUayuw1o+y3s/S8MtgKYOh8HWQ9GIkBFwgAogPeOKhDMqeg/VUyCrZpmaBs4hMYulqT+RcUYO13LGUeK4Ppry322NYWHzLWoP5oqMQzlZ+rd
                               Vq9icxzXhvbFnpK5+7GRikluUs4cy0FrWIGiAFM0VMYDXLZn0F58dq/otFBKmUK7wLlA6GReUf4JTc9ZoEVHEITg0/95Znc6TsT+I3NfXqhxDa1+PLQUgwMbDaUz55Labudvbq
                               V6He0DUWWI2xV8PUJ4eUii8SLhQBwEEIKyg8msZZYyMXUgO5NHsW9Sx1XNSgjZhm0MpZaJTXNsYUXnh7p0/phXFp2iUVVXLWEMOaTVOMRwWMC+HhXsJrV4VPXYPlHg1mNEHEYM
                               wAYwSZ+QdO/96AEDCMyfESCOLQqoHnSai9+rsT5Y2HylubntIfEOmZz0tjfr5zrtMsq0HopUovhc9cD+RJe6/+4WtRfHEOqW8gqGFygQ2/xoUjgHkocU//YKL0LKymQm71oM98
                               AxwXNXAtiUCJ4bZeonzm8pC9wnJvmLM3jZ2D2mq8marWQBusCOo8Qx/g9XvK6/c933TTcHkg3FiTGWEeOsJIpZ9/MO0OyxQrSm4dVvSQQlEMF0b58alPZqscsZasb/GlJ3j/WK
                               cjUz2Hu7uwOYqlubVXvybg+tqOu8snocCTJ9Gx9/IlWO+fw6uv0QfinW8uaX70HETDL8PZLdMuCi40Acxj4mHsheUEehaWU21Y+DJ3s3NRg1JhqnTyxK5kno3+hEejlN2p4d5+
                               EnPVWwqT1EVHx/kIjqtArENPv/xuIE3gszcMl5eFlzdiF6O6iOqkBhtehaFLSU0glUBmo/t/6i1l9eIedws2tdjU4ivxDHUxB+H2djT8r97TGDU5TjFIDq57/lmdp2nmzKu/El
                               jtBW6sKdKwMeux41IZfZNWbifBqalI9KLU+TXDUyWA+Rps00EaVYB9JwxdJITMwFrW0tFH9BFkAklQxuOSpX57J19QuLrsuTrwrOaB/cJwazfpLExSOwub1KnXTVC/9F5grQ/v
                               bho+fcNyY92eueSNNfUGh2GviC9rUhHGWddu04RU4N4WfO2u596usjvhTK9+nT+kUGXtdW+aqcBL657lTLk6CNWzMJ2UdoNzsRPQOQy/rBqkntfw3Tl8DefB0yWA+bbTIXqOm+
                               rM16g/ve+ism1cFSjLafvRS0XYHpdMC08vs/RbEkF9O9eWPZeC59KS595ewuak/bDWRCCijYnAGtgdw9Yw9rNb6Xt+2ydTetnp25Kpi51yXYg+icRAVtW7n4SgUfX459507E2U
                               zf34HdY0G/fCeUo3L6vSHleXA9eXPcv5Ya9+63wN72fVeSF0M1ynBtegO/JZqHMbupQrPwk8sy1AXVCj6Gw1UKfLNqpgqz439lAEYacULudKZlrqrle93ZwLjCaO5UFGlppD33
                               EWQpX+utYLLKUFv6UHX72fsDMWpv7gepvggAg4NWowX1lqDWwNla2hsrlfcHXV8N2vJaSJzLzgWglxjAqZpezWcAF8KUxKWMqicdUluYWH0ik//5bj4Z4ynOrsO+dL/I4Lc6oq
                               PiiTIjoS49K9eWmuAqmBpSzwiUtRfaeW127v1a+I1ZXt44lz16Max0QrbYQ2kNn/xBWQ88+mH+A8nrkPIDq4ond6bxxztJeyA0XeszAfNbhX6cJdzgOJifkAjclEFe+V3b0Jxg
                               i9XkbhlSxp1iUIamESWM6V3/YJz3AqfOlWTC/eL5qHM2FexfiACOoxOe566ndxf6qMHnree+T57IsJn7xuGfSEaSmntj2rzz2cxkSdPFVGU+XN+57fvOsPmmaecANSiydwIMQx
                               KVxF8u1QC3HkCbx22ZEnB6Te2l6ehOFXY1McCEWhLaXpRWBUKpNCmRaO0l+M2MAzJ4AazsOvvmdZ6QVuXlJW+rHnXputohL14u6ODT2rrKa0jhqoxvLjhztT7u7DxsDST6PEV5
                               NZpw60WYGVnvK7PuW5tyu89cjwaCiMiubJMHBABKEiqLNeYqnuwSv8+m3HV+84PvNSylrfcH2trsE4+bsEuLsT2BkHfvN917xpJrHoyPvAtHSdMveiVx9W8sCNlcB6r1uFX32T
                               qqFa7ncoPiMSXghxhfRYpIVm75SRmNy1P1XubAf2JoEGQtJPDReGACC+gHsT4ddvC1dXlLUl5caanloyexImXhh7uJQn9BPIpGx1vADjMjDaCqz0DEuZYW3JNuoGPA9VuL6ivL
                               DqeXsz9qV781EUBmmzVTEimESiA60mg1PGcd7x9uu3SvJE+Pg1y6WB5ca6ObSFEMAYuLcT2BwG3n7gmLrm16cwM/rC+fZ7cmIi4rWVko2ecG05inB0Nf4oxBHOVY8/qmb7FhP9
                               Y8/AebizF9gdK4+GF6slWI0LRQA1jMDDPeHhnrAzUpZ7yiuX2z8JAQoSUIvDYvHkbYlAYG8a2JsGRkWglxouL9tWL3nMCINXLykvbyhXlpVHQ+H1+6Z1FNIYwSAYeZwI5g3/6H
                               iWXvmN246Vvuf2luET1xLWluKKYGekvPXAsTkM7I111jSzCaZFlNcunZ+NeVtcXS7pp9GJOkjTcyrwnN/wXYBpAEts3toF720G9qcxBbp+BhcRF5IA4OAlfrAnbA2FraFybVWr
                               mG+L81T/lprgsJSakEtJKs2btNXn2JsEhkVUurk0SNlYbtcAon6xb67HirSX1pU3Hhhu7zT3M9SYEYGJCSxB9ewwnoHhRNkfe7aGgTyJDsfCK7ujOK5NtydF6Sic71ykI8Bq33
                               F5UNJLA9ZodKx1EeLwjuCb1VuchImHSb3c53giPfM6FO7txYjMsNDWq7xngQtLADVqVd2dsTAuhNtb8Nq1wHIvqrdAi/09gscyVsNEM3KmKM1KaOGgIGVcKHddycP9khfWc/qZ
                               IWnxpEPlLLwyUFZyz2dvCL/0nmF/Gj3xbZqgmkopxRL3301SjGOr7IMeeabqlnTm+KniQ2A8LWdOyTZQoiBLLwm8tD6tNBl0JrPWOidLFVEPtHc01s+hDLDnOLTlaFp3Un+u8H
                               GP/9bDgAuK8wdRlKaQgxDBU8VTJYA64USpPdvNjzXEdFgf4Kt3DFkCr10P9FJtFTWI3x/rA0baY6xCyhTD2Rp/NaIkmFI4ePfRhNQKL27kZNaQp83DXAdNUJXf/ppnbyL88i1h
                               VArDQlpFDeBw1OAk/ft5r/yscSWK84qZC0HO7pUYpQmqjKdFp4YadcpungRurhfkyYFkVvsZPz7o2vDbQojp5V5htzSnRkZOO4eIMCph6pQ3HgRKf1C63TojFEgS26lT1nnxTF
                               YAseLt8SaNTRGTUuDX3jPRUbiurPVjMUib91OJyjZj7WHxpOKwtEtWiS2flbceTFjOLRuDhOV+wlLdcqwhjMBqL/DbPua4t2e5vWN5MDRMnJyp9nNobOX4JqgxfHhGIVA1FRsj
                               VcVhlNcuStdJbDMSnLLe81xacqz1fddIXDXYoWpR1s3wvcackbGHqe9mbLHHAeyOlPd3PbvjdlvS6kYiiRiDrRqoPis8c0UgWy2rY1cubbUUFIlbg+1RjBos95QXN7S1px7AY/
                               FqSXBYCXg/IQTFNOzyKsBw6tmbePqJIj5lMMgPcuEbQhWuL3turHje27bsTAxvbSbnaoI6KcqoutsQUYDD4YN29uoLcH2lZCkLXBq4qry25YlmJ6xIuUF/wpOw74QyxMzRLuZW
                               i7bc2RX2p/BgH5B2xj9L3LK2irw8+7qBC+EDEBHSRHjtesZwGri73c5BJ3XUYD/26lvpKS93iBoAOBJsPuD/8H3/V15/4w1++p//I6RFo0sRGI1LdtQxKRxZalld6bW6hjrZ5+
                               V1z0vqubwUeDQyvLnZrdbA+6hvb4yQJKcT2kyBJwR8ONuxeByuLZcs5561vu8k5HEwELE4+TzLhpKEURkYu8P79ra4tR0Nf3McGd10mGSuLFuyVLj9UKvkt2ePC0EAUMl2LxvW
                               lwyXlw13tz2bw+ZLxpqJH+0LOyPh0X7cGnz8Stxnn4y4TLY2wSYp3/1/+uPcePWzXH3h47zy2X2+8J3/Bv/y//s/8Ru/+jM4Vx70nGtwLeNxyXTqGE9Klgc5S/2s1YxRvyMvrE
                               aFopeXJ7y+mXNv2DJUpnUnn/hvYi32iLs/au51r4EXgbWe49pKSZ4cdu61xjmW+rP7qSI+AWHqY0/ADj5G7g+Fe3vCuIwRAlPVlzcuRxdY6RkuryRkVY+6OxcoMvBUL+W7v/Uz
                               CfCLwDcd/Zs18PFLYVZZ5jw4r7x5v2RSKqVvl0ihComNxv+FV2Izjn7VIaN+KUNQtvYdveV1Pv2F38k3fc/vJ+8PSJIstsQWQYxhtL/LaH+Xf/ijf5lH9++ws/0QkePblinw8q
                               qw1jsIaUU9AcEY4cqlAWlyfPlcVLw9fvUjGrDqKHyU5/rS3SWGpWFSNUE9bWj2R5PHwnUiQlYx43H1+Acp2qePcZYomQ28cqmI/Rlt++gAHOgHLJm2Rd7z1xydu1PNZv8fYFgU
                               jWdcIfZ5nJTCnc3YudgdU+p8mk9FgdTG7NEX1xOskVnXaB+U37w9wR2fyPWrwLfdufeo+RL4nLiQBDAPVRiXyrsPy1mH2NYCHAL9TPj8zYRBLqz0pMqEEzY+9p38jt//pzFJir
                               XJqTOg954Hd9/l//P3/xr3777H3vYDjE0OEcFxBDCPjeWcNDUkWfpYE9SzCMCEg78Fhb3C8usPeuwXhmFhTozhH0cA82NzHE4jgHmv/ktrBb20WyMMJSbbGIn9DLvsiGPKrhAQ
                               Sk0Jx5ylCQEYiY7lwgl3toTSn756OY4AIiFGw7++Fmf8o+Ny0Qigi+xtZ9x84YoB/gxw/ejfjMBG/3HjFolsemXFktlYPlx4bSXAoURWf28zsDeJM1SeCMvLy3zb7/1BTNIjz/
                               NTjf9AvTjhU5//btI8rhSGe1sU0/EhZ+FaLvROaEncz5KY2zCnPDPTDeTkpimCVsvig3HpJcqrayWDPO7tR2V8cY+OYVGeLLV12hgePaQOW15fjQ6+F9YKEtveC16n/qYCuRHy
                               ls0743hU0SAvlCR4shMX+aU/eSsZsyRhZyTc3xXu7zSr+Tg6TomF1SXL5RXLtbU46x83LqrwaM+d9B33gP/33nD81KoFnqoPoH4JY85Du0euCmt9w9qSYXPfMC4C93Z9K8dOTD
                               EO3N8NvLRhuLxe8PLde6ysTlleXmZ5eZl+v39Mt1phe3ubyWTC9vY2qsorr30TH/vUN/P1r/wsm/dv82u/+L+jVU+9pjjaBNUk7fk4ypkrN6943tkUdsbC6w9Mt8Sak8a+GuNX
                               LykrObywpozKqFfY5St6ErdE6Tmub96r30vkVC2D41ATyL1dYVzA9qjKu2jp1Rfgyoqll8V383zRjqfvGHy6TsC5mDS0J4JaWurSskHVsNwz7E4CD3abNw6tW4zd2Q5sTT2/R4
                               WyLHn06BGj0Ygsy7hy5QpJEodmb2+P3d1dRqMR3vsDBR+NjSpe+9x38bFPF9x4+ZPcfvurfOVL/wJaLmbrJqimXqa33OMo8WV+9VL0Ll9dVu7uCW88NHX5+blwc125PIBLS3Mh
                               1g7nzAVspdjcFSMnTEOM45/Hq39/VxhOo/Jy3c6sFVS5vGwZ5PE9PF+049lFBJ5dFKDOSJt51VsQQTVea0uGQW64smK5u+3ZGfnGyzcjBx5diDHZyWTCZDJhOp1W4TOP9x7n3K
                               Fl+jyCd4gYXvnkF7jywsf52Dd8O/e//L+yf/erWNtuRp9JU4XYXKTtW1mr8L6wFpuKfOyS8pW7hteHXZ5PTFX++JWYYDUvr93mqoSoxZhLu96LRzENwl4ZnXL1NbQ9V1DYHcUi
                               s8Ix20a2mfWNwCA3XF6xpInMCLFbtOPZhwIvRBhQK4kXK9EH4LXZnrAWh0wTw8euGlxIeOt+dBZOy/Z709rAi6KgKAru3r3LYDBgZWUFay2myl48eoyqMtzfY3Nzi3ffu8u9+2
                               OGW8pLa9FwUtNywlRFvcZuP23a6FSo9+rrS8q3veK5db9gtzSVPHiDnH9gkCufvaGkSTcFHsOBc6+LscbriF79QjOKECiDa3WuOr2+dMKoUG5vxtRfXxNIUx+SQprEBq4vbFRe
                               fTlZnOXk66nSzTszxpPHhSAAABHlUjZBEYY+namsNn3YsZe88A0vZoyngVubjknZLWpQI4TA3t4e+/v7rK+vk2UZeZ7PjEhE2N3dZTgc8vWvf71qUS2U3lMEeHs70E/g6kDIEy
                               Fvu8VXYqcekba7ini4RvIBZVqUWGtIq5zzs4jACNiWOgyHvPrSXi794DyPe/X17HYoj13/qFDGBbz9UBgXBwPYWJKsMvw8Ea6sWnpzTos25lsbvsVjGvRmeJq4MARQIzWBDTNl
                               HCxFsEx90qoFuABLueEzL2ZsDgPbQ8/W0B/rHW8KVWVrawtjDKurq+R5TlmW7O7ucuvWLcbj8SFSmMfYwTvbymoPVjJYWdJq1dDqAlAPXgyCntoS/ORRiYQ2LQLWxhz0tluUs7
                               4hE0jOscdXDlKyfccAlZEoerq5H3i0H9jsIMRRryxX+sJy37LSN50nbEvAVD9Aq3f5aeDCEQDEF6FnPD3jmUjAqWHo2l1qUNgYGDYGhtU9w6jQVinGx54zBLa2tsiyjJ2dHd5/
                               //2Y190gM3B3quxOYXkZloGVDiMfu8wIVeV8ByKIqDvtJkHJs/O/AvkT8OqXJAQ1nQ1fqrLxdx4FRlPlwV5oXZJb4/IgRhVWlwxiuhm/xVez/kUz+cO4kAQwj751BCA1nlFpmf
                               jmL0j94C6vWDYCrPYN20PP/fmoQcuHKyI45yiKolUxR/0ejpwSjDL10LOx0UlbPEYEHaenmPrbvgw1LmKV/JwzPsTaizjjdyuMqe/81mZgexTYGWk3rz6w3heW85g0VvVKbY3U
                               BIyGcxUuPU1ceAKoQz258ZgUlhLPfplQhuadYOqYeB01uLqacGuzxAlMiylJmpIkSWtDaIvagaVay5krQwdrqZC39/XNiMA7jzUOsZZW7raO9xt8IPFh1ga9LWIZdszVrx19na
                               4jwO4Evr4bqtTxbl79fiZcHQiJ5cCr3+I6YhpzoGc8Ior3USD1ecBTJQCpZswu0k1a6eAZgbW8xKuwV6REoVxp9NDrvd1SJnziWkqSZRgU5xzOOdI0bbSkfyJjweNNUC/lcRnd
                               ngiUUExjA9Isj9WLT/gejjbNbCtWUgtxgKE4JWvvzPMITEsoHLz3KEqdB63FTJrey0GdyAur5pAGYluvvhHoG4fIwR11dfE9izXDsxEEqYmgYzgkxpaVjbygCIaxj66WxuFDYs
                               QgOfIWl2VJWZZkWUYIYRbia3txXernXUUEa1UzD9uBCFAlTCeIMUiSxXE+BxHE1crxTTObJuHUQhxlEIZOSJMM23J9Hmvno9FPSri7XUmn1X9veI+14WeJsLYk5GnMUWhzNXUa
                               s5VAZgKJnM9sn3VM4JkLgtSDcJKE1VnITCA3gUmwuGCYhPN7touiYDqdsr+/T5qmZ9YJ1PfinKOcTNkbKyEISdJBmCTAOETNwMScVcp8PDQEtJjELYHpoKlO1VvARYXdLr3zYp
                               FOzNwr5oQ42joK6+5E93Y0qkSP2+/vtarfX+kLvRQGVaFWF2rMTcBKbK56HuiRf58Vnr0PoNJEM8aw1LeURXtPvRJ9BLnxJCFGDdo4Cx+/JCGEwM7OzowABoMBSXJ8taCqMhqN
                               IgGUJdtDpRgm5Cms97vtBl04+LGGmQBqq3HxHnU+RtVbllJrUFzhOi8g6lz9SSW91XUd8s6jwHCqPNwL3Z17AyFLYJAfLgdvg8x4rOi5DT+2nZOOMqZPHs+eACqICP1ewlLPMJ
                               16JtNuhtMznoAnE880WKbnWBEYY2ZGXRQFSZKwuro6i5/PG75zbnYfCAynhnEpTErDUhpY7ftOj3xGBGpiE0/TXYa7zlc/6ToO+jVWOrsdjG3shLGPxl/La3fBne0Yw98b6yzF
                               uS2We8KgF0N6XRR8AFIJpNWsfx6vSpoaEltlA1wgQZALQwAQH3Jm40D1ewnDUUnptNU+vN6bpiaQGKWvjqFLcdrd2ywiM/9AURT0+/1DlYEn3QvAuBQKZ9mbGjaWPC4I+dy1No
                               ULMWQ2VaVvfOcXctaAde7La8PviqDgVNgtBE/7XH2pxsKF2KTknUdRZXfeq9/08oxAngoby1Jlh7bPvK0LxvppOOTc6zLWxgh5VmdfxrZzFwkXigBqh0hUthVWljOCKvv7Zexg
                               61oKYxK96ytpQVBh36UE5JCzsG0gy3vPcDhkb29v5ig8/Roqb78XHuwnjG9ZvuEFJe8kZx4jHiOfIKIsGTdT0mkLqcoEtS6xbHs80bnnFXYLE6Mxc39reg6pUnanJXz9nqfslK
                               uvpFawFq6sGObLJ1pJz1dk009D6yjHofNU4dE8t7FvwwXGhSKAo5CqfHRtNaN0ynDsKV1sh9W2O5AVZS0tKINhEhLKIFHbvyhI837rGbDLjBklxOHXbhmWe8rNS8pyrvTz9k1Q
                               VYV9n5KIVm204x61bfy6bUltbfiFxuV+Ebq94LFpprI/UW5XbbTiF7RoH1559XupsLZkyNN21zAjLIlRpSyJjUu6QDXWTiRWULFPPAz7QeGpEkCojKYLK6aJsLGaMJ4GylIZT3
                               3r0lSIW4PMFEyCRY1jb3cHFdvY2/+ksD8RvnJbuLIcm6BeX1OSDk/DqbDnU3I1pBLo2Q9OTUqJCUxlgEnolgRkJEY63t+NmXuP9jvk6lfnWe0LvUxY7nVrKQaxe3R0snZ/7iLQ
                               ywxJIuSZMCoE95xkAj1dAqjiyCp166T2qkC9zNDLIEtltipoizpqYGyJaqz4S9OUyWTC0tISadpyKukII1HF+NG+sDOOBUOfu9ptOV4ES4GlVEMigf4TJoL5ppn1d3bBuw8941
                               J4tBdmY9AW60tCngqDXB7zZzTFIAmkFrJzSvP3ckNihSztHmF4lngmW4C6AYjKQTsqaPdS9XJDlkKeGcYTz3jaLbsQ5mL4laMvSZITQ35N0GpJXX344Z6wPYTtofDiqvLqRpeO
                               MzANlpJYSdmzjkzONxUd1zSz/TjD5r6wMxTGRdXItLVWQwzjrfaj6KbpkLIL0LPKIA2kVVap024MkGeGPBOskdbNXy4SnqkPQBV8pS+VWam2CM2zukRiVlcySBj0ld2hx/nQaj
                               89j5oIajKYTCaH6v/PvibFOU/PlmRW8dpcYLJugro5gv2p8Pam8NkbykZfZzoCTU4186irYehSRqR4ndAm0TTu84XN4rCRtTV+F2A8Fd7fjkviLgo81kSv/tUVS9DQSYjDVHv8
                               tSxgRA/O0fJ+6u7JvVSwSbXfb3meLqT1QeLCOAFLH9gej7m0lMdadWnWoW8+arC+khCCsjt0+KqvQFdfTAhhRgR5npMkyYnVfyEEQgiUZYlUQhirvRAjGIXBB5l5ts+CkWg4ZY
                               Av3YpiFN/0QqCXw6DXvglqqPLvqyttdFzMZdDG13z42DpXX7i9FQ1fD/x7za67ktdOLVxfs6RVi7PCt4uYJBKdv6tZDAl3zdWfRQfyA5ETaXme2AdTGZ+i0PwscGEIAMD5wOZo
                               RJ4k9NKUzNrGRAAHRLCxmlKUgfEkUDjt3OKqflDT6ZTpdEqe51hrZ5WDtYR3WZaHmnBC3QAV1nqB0gsTJ5Q+GmSTsF0dPhyX8DPvGDYGwquXlY0lYZDH2bQ95ptu6ME/s1n5oK
                               CmrYxXLcQxmgqP9oRhB8Xg2qu/lMUOUYP84Nk3XUkpcXwzo/STQK+jc692NCYmOqA7CDbP7smFQOk9LgQuWBrAxSKAGlPnmDhHP01JjWEpy1qfI0sNeWYYjQrKwjN2568RqMVC
                               syyjKIpDhn8aUqtkVpk4YXVJ2BzHsF+bJqhbQ+XBnufFdWFjSXj1siG17bX6Dpml1Evy5pV0x12bD9GHMZrOyWu3OEddYLOxYumnwuqS6bxUXk4CqVGWkvMl2+ZJnEy61GLU91
                               54jw9K6S9uSOBCEgDEQRyXJRPiQGbWtiYCVchtIMuix7cMwrg8n9tXVZlOpxRF0SgRaHYc0EuVF1aF9SVhf6rc22tVe4o1cHdHubujbI6Utb7wqWtd7+fAAXqekPW9nairv1s3
                               zeyiwLNs6WdyLnntpSSQW6VntfXyfB55WlWKnmO+mDrPpAy4rs6op4gLSwBwwKQT5yi8Z+IcgywjS9p0yY2fzG0kgdwGxs4wdabK5R+ztNLc0QfNy08fQ7XcvrQkrPaEjSXl/p
                               6yNW5eCVl/9d0d5eGecn9XefmScHPDdNY8bH0bCltDYWsYy3Jnq5mWWiQrPcPGsiXrKK8txDj+chqw53DuAaQJs+jCeYZRiA1YS9+tXdrTxoUmgBp1XXrpPbuTCSLCWq+HNaZx
                               LkEdX0iMspx6ltLAvksrcc89siwmAhljuht4wwsJ1Uy5XLUQe3EN3tkMTJxSNEx3rqMG2yNlOFXeuB/4/Es2Jsek8Xue5HZTiC20xgXc3qqEOFp69WPGYqzMu1E3zbTtDd9Uzr
                               31yqs/E/Noe0/VHr+XSavU48YD9hzgqRJAYmuJ55gU1MUbGqq3ZWs0IrGW5TwnaRE1gMpZiLKSe3ZEUQ2zZX2v15t1BeqKWU3DWZ9TZgUrn7pqmDh4byf2NGgqZy5yUDH4i+94
                               eqnw+ZcMSxms9KSjs/AAB00z4dbmQdPMdrn6lVc/Ea6txR6PXXP1k2O8+m1RJ6Fl2XlWTc+JhZ+BZ6MIRNxn1Q0nOuXVE5s+bo5G9JKEXpKQJwmmDREcPafqTOK7jeDn0QtbSs
                               EbWjUwlUqb7jMvpmwPA5v7np1xjGI0fUmDxsKan33Tc3lZePmS4fKg+x6/9LA/iUk8+5MuUmXRqz/IDatLsYVW19bhmQlkiadvuzv3YhxfSBJprUp0+MbqlKjnnwSeuSKQrZw+
                               XZ+H8GSiBvNQVSaTSbdjiXv8gcaeAFujdgU3qrC+FOXMH+75AznzluWsj+aiBsOJb3EFEYWD25vC9uggDt5mDISoxpxXhTpdm+FkxmNRMuMxLYud5pEmgjFC0qV0cnZjoersE2
                               I+e6duLd2//oPAhfABiEQn0CBNEQlMfPs89qNRgzxJ6KfVZrjjNXU6rvrG9Z6wgjBIYb9QtsfNz1Fnul1esVzS6CzbHQfeb9HXoM5DeH9HGU5ctd0wJGe4t4NGMRDvYTrtRsyX
                               li1L5/Tq13p759Xci7X4cSw6Y97wz4HUGCyCELgoTHAhCKBGaiyJNWTWMnGOMrRT0TkaNRiXJUsCWRdxz3OingVXenFpv96Hh8N2qXX1JW8M4vL58rLhzrZne9iuCSocZCt670
                               kS+1hXoHorNn/aViXXEpf6lwaGLI0zbZdZP5EQC7XOIcQBUYEnz2Lb9eBD+3JvQDQgen5jTcSQVg5rdzHs/uDanvUFHEWs3ReW0hTVhKErCVUaZZtzxNRRz1Kvh0kSQjHprEJ8
                               HmiV+Zck8OKqsDoIjEshtKgTCJWzcNAzfPyqwV1KePN+GaMGpbZSIg6qFKVDnCfL0jjbd5zYaq9+nbJbN82kZeuzk+S128JIDOP1+0nn/AYlSpBNvMMC/Y4rh/o9zqteDTL3DR
                               cJF44AasT3SFhJM7wqY1fiVfHa/AWpzyEimLwf1XLLAp3v3CIWxHzgnVxmqaUC6/2YHjwqpVWdwEHUQPjMixnjIvDeI8e4QxNUVaUoSrKsfUOUoMRmp4lwZSXG8efz7BvdC2CI
                               HaHzSsyk07hqzNgzRujlFttxjx8NX5l6XxWo1aunliXrRCLq2QT7HCQCXFgCmIcVYTnNKEOgCJ7SB0IHhT8xBsl7qHdRMVcDuvc1NN1All4G9Twthk6tsl6lBxdeKFzz6AXEJf
                               dSbvjMSxlb+4HNJ9AE9SzUXv31nmU5l3N59VMJJOZ88toiMeU7TQ1J0r21mAsBp+fP3KtD2wktvabPEE+VAOp9WCTWDqpAxpAZw9TEHOsuzkIAsQliE3CObPsXmZgBjG8jg49B
                               7/pT6+umQJ4oeaJMrUQ585YGpVo1QV02PNwzjKbK+9uutdRXE8QW2SZ69cOBwEsbPCl57TyPW4407e7dK4InqFI+IcM/aJzSfuSfFV083RXAMRVzbYlAgcxYMJAYgwvdogYAJk
                               nohx5JKCj3vsJ0/D6SrSGXvg3oFkrsun7oJRrlzIO2ljOvdT2vrFjCctUEdeS5t/NkilAuLVuWc8NSLybOdCnUSavZ/kl49ZNEOs/4AGUIs1m/K0Qqw++Y0DY7z5F/nzae3Rag
                               9jirdg65pcaQiNBPU8auZOp964chVNGHrE8ehoxH27hiCzUrWPsNBCwBy1kL9HpPm5iYl25Mu5LdesbO5uXMfYpr2wSVg6jBtdWE9zZL9va7je9KLzZSrRV3u+Tq2yfk1U8Sw6
                               BvzuHcA69h9o6ca6MnUePhvN38zqlG9kRwIXwAtURYpz6BIlhjWO33CSGwO5ngQ8A1PNfh+n3LILOEMGHqRlxPh2xzjc3wAiU5AfMYESiCoCzZkiu9IR9b2cSVJd71ub9VUHql
                               dM2FSSIRVHLmyWE586DNTlJHDZYy4bVrKXvDjM3dyWyszxxTon/h+nIai3RaPhrzhLz61I5B6zCJxRrb2nCDKl4DY+fOafiV5p9p2YH5COrS54tg/HBBCACIKwIXogF06IwZDd
                               iwsbSE8579oqD07bvx1OdZMgZ1UzbsHS6Zu9znVUa6zFDXoGppHRA20jFLScmn1x5g6mYdBkwivHQ1Z1oGHu06ijLEJictdudH5czHIcGrtGqCaoxgRMizrJIscwQ9ftla58jX
                               OW7GtFPgqYt0etZ3lteOF1L5iqw/IAGaX0uUNFN8CExKd07nXoyxqpzT8Kvlk/qu9YofDC4OAdRQRV3MDZb4Rra/KWvZ6PeZONeqNuAogirBOYwxXDVvgMl4oDcZ6wom9VwabP
                               Hy8g79pERPmJ3z1PDSlYz9sWc0CZ1z0OflzMtgKEL72dAYIctSvK+SgsKBMq9wPl2A3MatS9fWZQcXGbvx0PE8SkwNdz5QnEOII1aOWvScrdZnhn+BZMDmcfEIoEaoZkvtRgTR
                               w/5kbi9m0YExBdfk65R2Bd9PWV7awas50fhn16Kw3LMs9y3TErxXJkX766jlzHPjmYaAU2Hi29+jtSb+hIAV6da9pnqfcxt9Hpk9p3MvCSBKcY599cQ5fAgU5xTlz0yUoku6Fo
                               RBFRG4uIZf4+ISQI2KCERBjERGflaXEgIBMLpPYgRv2nvqswRIhDSBoowtsbogNkGFTELnJqjW2s4O2MwGUvHYc5Tlzs5jlcQogdgKvC0K55l6F1c2dF+oZ8aSGMGe4x2rw4EX
                               3O5nuPgEUEMVE2JVW6iXZk8AXYpVQlDGzjH1E1Z7PdIOIiKJjRl9eQbjqR5Sz200HBxEDVQVxFFqitI8atB2L1p79ZdsyXn2w9HPoo8132z7HFSV4BXnY3JYlwLd2ueTm6qBZ8
                               d7ioYfohCLPj+lwk+VAKRaUp0vJ18xwRGJIDmXO0UVfKjTPtuJjGlQXIhS5laE1UqhqM0ev+5CO6haWw0nMQ+9bZ9AQTFALgUBqYhgvhvy+aYjI5FWlmw5C+cpNI5KzM5jYoTg
                               XF13q2rFWOBT/aqDfDlU0Y4kPZfhoxrVoZ/EjP8MsgefjSBIpSN1fiIoURE0CGqk9SysKHtlgUHoJTF3u7Gy0EzRRnGqbI5GM+FS0XbClLWs1spS1NGfFLEct42gSA2DVkRgcJ
                               rgOwpX1MSSiJJb1zlzb75pZi83GN9MSfnotSgHM/6T3Fd3Nn7VmAn5JK7lGaYNP3NBEKgNpWPdviqhjO3DjTHYDjrOTgN7ZUFmbEw3trbTS1F4z3Q8JjeWxJiqEqwdEgsrfaFw
                               UFYagV3eMUMgkwKnli4JKwalbx25OYcnXQ43zVSF0EEYP6vq6L27ACq7lTaABq1EQc6BC1Av8Ox9ABUDS228oUtarxCcJ+AJIWCMYNN2tyZAGTxliA0crIkVXe2vJOaYF9V5Ei
                               PkLc+jRJXaNBES1z1qAGDFYw4RwBkvXaULIDacy/j7ucGes2nmk/DGPzE8JgrSzXhNUoUVn73tAxeBACqICDZLSDAE7/Flt5cvEgEEH2L2WAeB9yJ4CDFnPDO200wOMA2eMkAR
                               Arm1sYahJbIEtJpBCwfjSZcmqAf/e+A+lMc+dLS7UZeCojwz5KlgEznUh6gJ6u9KjSE1dpaU9EzxhERBjDUYY6IgiJync8GTxYUhgBr1QNkkwRVl52KL4AMhKL50JFmKdPARuC
                               pZZuIdS0lKIu3OUT/meB5lIvE81ghtXm0h1rznmWXQq5qgutChK1CNelcdTfS8xY8icY+/1DdVt+eDb2lzEiMwMMn5nHJPDIqEc5aHV12XbHIQbpUL1hvswhEAMBu4tFelr07L
                               biW6VY1BOSkQI52IoHY+DcsCEWGQpJ0SZ5TYbHO/LDAiLFXn6dL78GgT1KLrS1WNTxdjU63SjA0Mjhh+K9SCLUkax7rlPv/J6vlXKcjnNHwRQcxhw7+ouJgEMIcZEYSAuhINLQ
                               PmFTQo5aTAWBMfjDWt+9epxqhBYgym1Rx++Dy+Ok9aOQoTMe3kzOWgCWrplLDv8dPolW73vnUYx8rwsyT2XkySrnLOgohBrJ2Fh9s+17oezz8JT7yGKNZ5znPVM/7FKfc5HRee
                               AGqIMUiWRzWfigy6IPhA8AGb2BhC7HCOJ9XzrQwh+hkqEujia8gSYWWQEoj5/dMuqXQtUMtuZWmbhKN5SCTfyvjPg2mI8l3neh4aA6Xn3QdJpZ0uIhDkomzxz8RzQwA1oppPLM
                               vU4DsTgXexUnAJgxNl+pRUgI5D4T0FnqCBJWuqyrMW0CiNBTHH3/snTwR5ZfhpctDdqS2mzpHYxxWJW4/XEzD8TKLUnHmShv8c4kIRQJshFGsRa1GboM7HNjYdvi8VQ1L9O9VA
                               +QyJoAxV8wsJqLRLd6499mkS9fHSxFCUgWnpOzrU4hYnSw1ZJa/d9R0vvGdaOrwqK3n3pi1xxeTPteRPK5n4ti3M56EQjf6D7iP5FHBhCCCmlrY/TowhSQ02TXDTblEDARIEWx
                               ndKHg851SN6YCZPJQqonPpzi3fsRg1MPRMbbwOaEeQ1gjLy2ln555WCs6joujc/g1q56meS8lHoBIokXM19Ir+GxgHJbORSLqc4yJtDy4OASjsTwTbj3Jats02qqpnj85C7Rw+
                               jC+HsGwSPMpE42zTvrHWExuVmO6MxET6lhBhpmFUdyQ+8z5qbQCjcdZvOX6+6uEwKsqZ3kAXBI1VoBPvW/WEmIepxqBXtaDrfC3V+E2CzlKq2hcuxfNMWqo/f9C4MAQAkV13J7
                               HRRJ4oqY0vbatkEhOJIPgQ9/kdusLUA7NmhUJhGqBQPVep6Xkgs5j0ObsWz+mfze5jLi9IavWb1tdXNRypavHLzkIcMsubKEPAd9yOCbH/QipC5yAF0WCdxmffOdJKrOlwoW6p
                               fpHM/4IRQI3SQ+GFPIHEaOx33xLGGkxiGI2nlM7Ta+tYq5CJkFuYaHwZxud8gJm151KqOS8OLUGlLkQ6X2rqxEXZrfMKccQZ/3wSXrVzLz0nU081rmbKczzu0seKyYtQwnASLi
                               QBQJVT76AgVsgltgMRKBQamGjAo1gMvQ46AgrkIuQSnUjlOYigZxMyY88lZ378FbZXTDpggG7fOnWO0odzzPhHrukcnv1MIDnHjD+7p8rwz9PDr/RQVDP+RceFJYB5FB7GZeDh
                               fsnGUsJS1fG1DUpVHJ5SA7kYso6CInk1u+QijIJSdnBMZcaQGENmDRPvz7cikMoQnSHrUPfQhTxK7xmXbtaz8Vn6wZPqWZzHqw+R1AvVqjtyN3iNzV3KEGf95yE+8FQJwFeUKB
                               JLd1sdqzApA/f3SqwpubaSkVohMc2dKgp4lLF6JhpYMpZUTCsfQW0uicCKjVLdeyHm5Tcl/PocVgxLiaFvYxNU6ejsCqoMiymTUljK89gk8wmHp2pjH02jat+hLk9PGU/aqz8J
                               OquOaHsdcSyEIhhqH8bhZqANr+UZaYg9VQLY3N4FFGMsK8t9rLEkiW188yLVi+jhzvaULDFcXk5JrZDa5h1pK7lGRuq51MsJpescNbAC6zZWeQ2Dto4a1A1Ml9MoJKLqKyJoKZ
                               qhkdz2JhMSY+inKaZqSd0VtXMvBGVclp2X50rcl9sOBVnHjXd+Dq++EAOiR736Xe7Jq1Cqaa2MdOg81QrSd2hq8yTwTHoDeu/Z2tknTxN6vZwsTZGWm7co/xy4vTVlObcMcssg
                               j5JcrbrXzEUNgvOdeslDXBGcJ2pQt0kLksz60ktHL7gLgb3pNKYYW9spjKYKU+dx59iixF4BQmYNmU1IbbdtVzR8qfb5nU4xm61LrbaD59KSs3hNOgmx1tcSxbBi+nbXMOeTwD
                               PzAQhQlI5pUdLLc3xugbS1SKcIDAvP/tSz0rPkiWF9qf1tGWsw1kQSCLEfQBdkImQ2OpO6Rg1UDCqmIgFFtJsBFt4zde3j6KqRRIbT4lyVdv00iYKbtn0PgxopcTuTStQm7IqJ
                               xtXMebz6aBIX92qjGlDbBK3K5+pDbG4bnlBNyXnwzJ2AIsKkKChL+NdfK7m6avnMi3mH88DexDMUz7gMLGWG9X4HIkgsBigFxoWj37GRR08EraIGRbXcbItIBCAqmKcghx5qwU
                               2tsjI7Gn8vTUiMIa1y/rvYXEoslT4QZ+tmuYWCewIzvmBBz/cMbj8q2Rt7itKfQ8vhyeKZEwDUe024s+l4uOt592HJN7yYc/NSUu0bG56nSmIZTj2TMrA38SQ2VPvOlvt7axgF
                               ZapK3whZS5GK+tvqqEGvihp0CtmJwSuE0mErwZQnCdU686475uW1Extbd3c5n6Ue63NIdBNXX9NK76DLdSggahBNOY+rMyhs7TnubJVMy4DzemGMHy4IAdQwBlxQtofKL7014d
                               feE77jEz1W+pY2En+1s3DilGUbdftdGAOheYZ/ZRBOYd9Hke0VG2elNuZ3NGpA8KiRKr+/JRGo4pxHJJBUIb/zFaPUGW7nE78wxPyGWsmnLd1qZaWh8OTSTqdhHvMpu1078MVL
                               EaYuNgjJW64A62V+4ZRJEXjz7jRmAnqd9V68SLhQBFBDJA6Y88q//OqI1b7lczdTjFGWe80TLOrcfjAkZoDi8ToF9bRx0dUv046PMtlLRkhEsHTRvFOkljOXqEnQhQjK0iEiVR
                               Sl+1irdlPUMSIYhNzazi+1Vj3zfOmrVlrdGnvMvPrafXaNqyCh9PNdmNtdjTWxt8P2KPD2/YJJEQ6SLi+W3c/wLAigVT2oKuyMPF/8Tc+1VeHamnB1zZCn7RpoAAiWRJYIlCix
                               Qq7tc3EaiSCXmH2Wm/bil3BQ8Vc7/Lp0OlJVXOkQlMxaXGjfDbktBEiqRKbkHH6JWpglnCNdTnkye/yYpx9/usAYmJbKnU3PvR3Poz1Px4BH91rpjnjaBBCA/yfwBeCH2hxoBB
                               7uKg92lRt7ynJf+Ng108n4jKRAilIyKYV+y2EXYphvqjGsZAWWOjoL63BfJAFpLQaixC62vURwweD1fF1xT8OTkOn2Ls725zF8iFGW83r1RRKmLuB8x2cnceXxxt2S/Ung7nac
                               UDoOzw8Dv0KXJg7nwLMggL8L/EPgnwPfB/x7NPSM1Wnrd7cVs6Ns7yuXVoRXr3aNL6dMSnABskTJW46GEJedUhFBVmWndboWDYiCirZfEVRGkBhDQpyZXU0E51h61oc+iaaZwV
                               Uz/jlDX09ixjeSRK8+Bu9LuvpA3n5QsrkX2Nz3s3LrFqjf+b8G/DjwL4CO3R+643zaTC2xtTNkY20Z4rbtTeBfAf8j8HHgBnBq/G+2M6v+YziF3ZHy/paSpUIvezwnPEtiLPo0
                               BI3LwMIJ1kQGV2L221mov8tz4Hk2VUVaJ5FcNJJB7aNosHl0QXBzy1cjgq209YMq7z4KTMvHTxXFRY+vq0itcmMl0E9iSK/NPt/MZfyFEHCFI4RuCVbxOgWnyrgy/K5FwiIWa3
                               KMWERi6m4RTl4tmWNWOz7Ao33Pr98qeLjr2Z/ozPE3P66njVYIYQ/4SeIE+OPAV6gUWx5u7na6u6546j6AN9+9B8AnXrkOsFP9fD9wDfhR4BXgZpNzGYkPZDhRvvJeILXwW142
                               9DNhKadVYYdqzAvfn0YSyRNBVZCGySe159sfihoYrHTThz1eFahdLwERoZekWHG0meUESK2pPPvtr10r9QtXuHOlt9ZlymmWot7ji6IDqcaAojF5dez8GU6/ttmyVGK/xnGp/O
                               b7Jc7rTIGu5ax/C3jXGPMDPoT7wF79h6dt+DWeWRTgCBHsVT/fU/38p8C3AC82OpnEyIAP8ItvBlb6wieuC8s9WOu3awFeE8HeRJiUhiwJsSNuiwd9EDUIJJV/oEvUoD5bbIJq
                               CGJbu5NbKfrMhamE7g0DfNl9to/XMaerX1tY68S7KDtuJKVd4PYA1sCkVPanyjsPHftzXZlaZqzeAb4E/EXgi5+9eZNfe/dd4NkZ/sEoXSBUZFDjDwK/G/gBYOm0iz2uIDUEuL
                               YmvHgp5RPXMnppu/psHwK7kwkQtQisUVLbvRgmr3LZu0YNVAWvBurl9dzUMykNEycnHAf/+1fGbA3D49whkGdZtW063NFnOVO+8YWy+Qsy1zsvaFw9tYWIIFZiEdMRN3rhPcNp
                               sy1yvceXMxyqqsp+8Xi3YiOxpn97P24xH+6Fx2Z65WQCmNsCjIir2p8k+r0AuHN/s/XYfFC4UHkAR1YF/7D6+SngW2kbNTDwYFe5v1vwaC+wvmT53M2sdZIKgPOC8zFMZEVJk/
                               bdawpViicQNSBErTxUZjNlV9RltedKTnmsaWY3FBowYlhKO8g/Vahn+7MM/yzcfqSMCmVrT6vzdjrNDwO/BPxY/YuLZPg1LhQB1DhCBD8G/BPgJ4A/Dvyp6mONowbvPXLc2XLc
                               33W8tJHwyReyZic4AucFR3S4pVZJOqwIDqIGSibSOWowTwSR0bq89OfowfeEOumU1CXUSteSIZGkmvXPlyJ9f1vZGirDiRJC691WffF/g+jY/llgAhfT8Gs81ShAW8xFDRzwjs
                               BPA38b+AxwCejHT57+pOoHuT9RHu0H3n5QspQZemlVo37MMarK9ISKwKBCalPypFdlFLZzsMGB4ORUNToKz4wayLFbHRScB+dqp9njn3nrgWNS6jFRACE9oX9dZuH6SnjsG1UV
                               DXWk4vj71jNkOpSYlD2tpNpqGjUi5Mnxc5JXPSQ9pkAIwtQZjFiSlp2XBVARxoVjZ6R8/f3AzuigDXtL498iRrT+z8CPi/CbEt/ZC238cEFXAPOoVwOvxdXAdvXzfcBLwN8kRg
                               1ebnIuU6UY7znlZ78+IU+F73ytx1IurPRNVaPd9MoEwZBIHxXFhzFVLV3je6ujBntzUQNDrBto7SNAwftZw4onnnuqVflqdWEdqmEREbxGufWu64Y6V79wZhblaeNviNERGE2V
                               cRn4jVsh9lfU+hpbXc57wLvAnwRuA8P6Gt9/cLENv8aFJ4AabxwmgiHwNeC3A98r6J9T5LcC15ucK9ZkK6Op8i++MuTSsuUbXszZWDas9GxL6eYYZkrMAFVHoCCoh061Bt2jBr
                               NvUkXnieA8ft6qPJiOLdoPxjv6KkxiGRdF611DXczpq3yH+ZTdNndnTTT83XHg3Qclu+POfot7KP8a+CtEH9UMd58Tw6/x3BBAjZoIYEYGP6XITwF/mBhC/DO0zKne3Pf8q6+O
                               ePlywtW1hI9fTenSvk4kwZIgcWdL0PaJXfO1BqlAr2PUoCYC7ZiQFJf659/j16E80zE5HqBwsTpv4rpVCtZe/VuPHFv7nvs7vmu6bgH8CPBFhB+rH8rzZvTzeO4IYB5vzJyFNy
                               A6C38M+JfAdwJ/oc25rIFbm45blSbBch9uXu52XXWtgWA7EcHRqEEi0O+6pK80CGqH6JnmXMe3qkq9ruuHJ2P4ldKuh9J3d1i+ea9kbxJ4sBN9CB2N/y8BP0cVzhOen2X+abjQ
                               TsCm2NrZr52FENMqv0iMGqTA5+Fkr9T8L2sf2s4osLUfeLgXbWGl/7goSWrtTPHmJIhYjNiKEGjlH6jhiKsCjCGNOcqPf+ZIKvBRvP3Iz1KBD6eszjkB9UCzUYHMKteWT66WPM
                               HfiFiLTVJMYo4NUU7dyeKXtROw9DB1MfRa78bCKT0D6urEeajCnS3H198vuL/j2ZvEFO0WPBp9ldGj/4PA3ycW6wAX37nXFM/1CmAeb757F5itBkbA/49IBv8Fcdn2jcCVJucy
                               VZbXdhUSeucBfMOLhrUlIWs9YoJgsdLDSI4L46j821TliAOFGxKDGFB/vqX50dWAnleipmqPbZL0HM7HWIc/nMqpSTan3RMahTh2x4HX3y8o3LwQR6vTPQS+TNxOPiA6noEPj+
                               HX+NAQQI0jRLBd/fw+YsHRjwAfo2HUQCRWCroCfvXdQJ7AZ28a+hkMclpK30Rn4aSwBIU8bZ5ifGj5IiBJXAmoPwjFdZHwM0TJrM5uwidk+DFXP0MwnQQ9jMC48up/9XZBUZ7L
                               q/820fDfoorjw4fP8Gt86AigxhEimAC/AfxO4PcAfxr4XuBq0/OFAOMCfvGNwPoAXrvueXEjYbln8C3eWiXmEYwLO0svtqZdrQEwRwSK+GqL8pTkpUUEYwVjbRVp6HSWmKtP0j
                               lzzwhMStgbee5tl2wfl+7cDA+I3vy/Dvyz+T98WA2/xoeWAGrURAAzMvhn1c8fAb4D+LNtxkEEtkfw828UvHIlcHk54ZM3MlJL69krqtDYWGvQIcW4viCTWqxK1Jk/Z4POs/Ak
                               nHt11p5It9dPqirQe9vK/ljZ3NcTfRJnwAH/LfDzwN+rf/lhN/p5fOgJYB5HVgV/b4+Vv7fK7k8Tw4d/vul5ogKu8N4jx61Hjod7jkvLls++1F7OHA5SjFUNWSIgZ+sQHIJSGa
                               RBjEHDkyeCJ2H4+1OPakzbPQ/uPIo5HFv758rV/8tEZ/GPz877ETL8Gh+KKEBbbO3sc2ltQM4U4KtEh+E/BlaATxNL+M/MdZuPGmwOPbc3HQisLZ3cvHTqTq6RV4TMpIhWBiIH
                               KwIrhuyEqINXEysFqZbnxmCq1FhV5e1HnslxgiBUgiDHnDOzcH3ZY6whyZITvfpnQYk9HbdHjkkZSEzaqfjIhyi59c79qBo9mtJ21legBP4nYubePwR+tf7jR9H44YKVAz8LvH
                               a4BHkduAz8LeDTipyRWXjYkINClgh5Inzrx3usDyz9rNICrj66O5ngTwhnGREGaTZ3bkVNAQQyYxicUClXeEtxQpuqEJSf/PURW/v+WALIsuzxfH9gJYdvecV3lh0PqjgPW6PY
                               RdhXzsZBnmEbnLMW4piWyv4k8Ju3C0ofz9nhku4RM0f/BPCID7FXvy0+UluA4/DG8bUG/0dFPkNM9XyNlrUGzitf/M0RS7nhWz/eY7lnWO2blv3iK1HzEAuO1DgUoW27DZnJjt
                               f5hGccX2sDmPZ64TM596DsjD3OH3RhaHomAcTAaKKMi8DX7hRMy7p/QSev/hvAnyOu9GYZWR91w6/xkSeAGvMpxp945UZBXB7+G8QQ4h8Ffi+xArERgsL+JPBTXxlxfc3y8WsZ
                               19cSrKElEYBg8D5naiCRgDWh49LtGDmsOn5YGT4dCpFqp9ykCIzL+NMpZddE6a2tfc/7W46t/QOvfksdh03gnxIFaH+i/uXC6B/HggCOwRFn4U9UP3+UKFP252mxdTIC93c8d7
                               fHvHIlYZArN69E8dG2UTsXDA5DoiFGDUz7vgaHLl3qfXSH0r457E08pVeGRTijEPiEK6oI5J17JfvjwL1tj3QraFSic+9LROMHFoZ/GhYEcAqOEMHfJaaD/guiVNl/SAs5cytR
                               mEQENveFtYHw8WvdPOqRCGKevJWuFW311Nrd+PennqlTJmXolIhU4+37JTujwKM9HyMa7Yal/ur/hii99RNUwsELwz8bH8koQFvM1Roo0Zn0r4ne5GvEzMJGOla1re1PYW+s3N
                               9RrBEGPZkJcp5UXxC9+4dNLKgQMEyr2viTDOfN+yWT4jhBEEhOkAXPE7ixdnwxkAuwOw7sF3HmbzPr51XtQVC4t+P4jVsFD/dirn6HWP4Y+F+APwb8z8T0XYWF8TfFRz4K0BbV
                               aoDqPVsjRg1+lJhq3EzFuD6DQmIhtfC5ly0rPcPlQTb72zxEBHtCDH7qhMLF7UYvPVz0ogr//NdGh/bTB+eEPEsf+32MAijf/PLBXl6rluGTUqrQnmfiXCvnHgKJpEwK5au3C0
                               p/kKt/6HMnjdfBf94hpur+ANGrvzP7w8LwW2GxBWiJg23Bob4G30tsd/ZfEuXKGvU1qPe+PsCX3vIs58o3vuxZ6RlW+sKcAE8jBIVREf0LedK6+u3x6+PA8KfucVXlpqc2EtOo
                               p6Vy6+GUSakzgmt5fbeI3vz/hFiZN9NsWxh+NyxWAE8AR+TM/y3g3ybKlq21PVdQ4caa5eYly411y1IWDa/JCuAoEgtWlJ/6yujYPPnTVgDLmfL5l0JU4fHHfac/UTOxhpFY07
                               89jFl7O8Ozax5O+PMO8OMak7X+Sf3LhdGfHwsCeII4QgR/hBg1aCVMAjKbdV++bFlfMnz6Roqt9PKPw0kEAHEG/9dfG7Ez8q0IYCmFT18Lp2Q0nkwAQvTC3d1SxlPl0Z429jUe
                               85m/RPTq/716NbQw/CeHBQF8AJgjgoQYMfj9wL9Po6jBwZ/rhpPXVi3X1yyfOaHW4AMjgOsnx/NPI4C7W8reWNkdVeXGLd4yORij/57o4PtJqqX+7YXhP3EsogAfAObkzAMxE+
                               2LwN8hKhi/yKmahXOCl9V/7k2UzUrOPEuE5dzEBpzV52JV4clnvPWoZFq2iwKkFi4vnywJ5oMeSmkOAbb3lbfuKTsjZdw+Vx9gX2Kl5h8gFun8ejWGC+P/gLBYAXzAOLItWOHM
                               JqjHPxLV6CxMk6hK9F2f7LPSE5Z7sS3Y9IQCwg9qBVA4z9Q7pmV07r1zL+BCVCbv8FbdIspr/4DAoaaZC8P/YLEggKeEI0QgwHcB/xlRquylw396HLVfYP5Ta0uGL7yak2eWXm
                               qPFSb5IAjAGmF7VLI9dNx5pIwLfez4hrhNjN3/58DPzmchLwz/6WBBAM8AR8jgDwD/JjGZZdCUAGr4AC9sJNxYT7ixnpKnMXw4f9yTIoDo1Vfu73ge7nke7vpja/EbEMCQuCX6
                               34B/VP9y4dx7+lgQwDPEESL4fuBbQI5tgnoSAdQQgRc2UlZ7hk/cyA9q/54AAdSFOG/fL9mfBO7t+CiYcMLbcwYB/DDRq//3618sDP/ZYUEAFwAHRGBy0O8B/hBRmHIWNTiNAO
                               qEn6Cxv8HGIOHaasLHrmVPJAz43kPHwz3Pzsjjw4ECz0kvjz7+f4UoyPoPiA7RKSwM/yJgQQAXBAcpxkAUJnkB+K+B7wbWmhBAjaCQWSFPhU+9kPPmvYKdUfNEIIgpxZd6jrfu
                               l0zLQOkfl95qQAA7wM8A/xHwPgshjguHBQFcMBwhgmUiEfxtVV4OerwwyUkpv7HWQJgUJdbEIpx5hZ/jCCCE2AR0NJoAigsnvySnEMB7xJ9/l2j4+/XfFoZ/sbAggAuKeSLYGs
                               Jqn99BzCr8DuAQS5yV818UJUEVI0KSJDMiqAnAGPBe8d4znhT4hoolx3zlXaLC7l9K4afnG6ItDP9iYkEAzwFevXnI3v8Qsb/BnwJ60JwAahhjsMZgrSXPE8rCUTpPUbi2WXs1
                               JsDfIPZl/Af1LxehvIuPBQE8RziGCL4N+KG2BFDDWoMRQ1meXtRzEqqv/GHgF1kY/nOJBQE8h5gjgj7w7cbwJwT+HU5ognoSAQAd+o7PlEX/B4nqyb9AFOZYGP5ziAUBPKeoSU
                               AAY1gnphj/VWIF4iHx0idIAJvEGP4PAvdlzqu/MP7nEwsCeM5xJGqwRKwx+OvAq1Ry5k+AAN4D3iH2VHyX2H0ZWDj3nncsCOBDgiNEALEM+QeB314U5bWOBHAf+FfElcVPzv9h
                               YfgfDiwI4EOII2Tw/UVRfndQ/UGOEy89ngBKotH/DIuU3Q81FgTwIcY8EUymxR8gZhX+x4c+9DgB/FdEw18U6XwEsCCADzlevH7IHzgglh//B8AfBmxFAB74MeC/I5bnDusDFs
                               b/4caCAD4iOEIE68AV4G9WBPAngYcscvU/clgQwEcMR4igXxHAuP7FwvA/WlgQwEcUMyKofAALw19ggQUWWGCBBRZYYIEFFlhggQUWWGCBBRZYYIEFFlhggQUWWGCBBRZYYIEF
                               FlhggQUWWGCBBRZYYIEFFlhggQUWWGCBBRZYYIEFFrhQ+P8D0bG4bMAJWE8AAAAASUVORK5CYII=
                               """;

    public const string Back = """
                               iVBORw0KGgoAAAANSUhEUgAAAWAAAAG8CAYAAADgnX8YAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAArISURBVHhe7dzBjfPWgo
                               TR0kQlWGnIgQhgGAIYCJWGzLA4Kw1M9usro/t5SotzVj95N7X6eCG0fcpX2/EFAL9yOr5Ikv85vgDg/8ffq7wlyba5AAP8N51O/5fa3U3YDRig5OTmC/DvWtc1SfLHH3+8Xp3i
                               BgzQ8/YG/Co3AD8zz/PueVmWxA0YoOfbAK/r6vYL8C/6NsAA/LsEGKBEgAFKBBigRIABSgQYoESAAUoEGKBEgAFKBBigRIABSgQYoESAAUoEGKBEgAFKBBigRIABSgQYoESAAU
                               oEGKBEgAFKBBigRIABSgQYoESAAUpOSbYk2bZtd7Cu6+756Ha7HV9VXK/XJMnj8TgeVdgzZs+YPWOfuudyuRyPduZ53j0vy5K4AQP0/PoG/PoCtEzTlCQ5n8+JPV/YM2bPmD1j
                               rz3veukGDPBhBBigRIABSgQYoESAAUoEGKBEgAFKBBigRIABSgQYoESAAUoEGKBEgAFKBBigRIABSgQYoESAAUoEGKBEgAFKBBigRIABSgQYoESAAUoEGKBEgAFKBBigRIABSg
                               QYoESAAUoEGKBEgAFKTkm2JNm2bXewruvu+ej5fCZJpmk6HlXc7/fEnm/ZM2bPmD1j73o5z/PueVmWxA0YoOfHN+Db7XZ8VXG9XpMkj8fjeFRhz5g9Y/aMfeqey+VyPNpxAwb4
                               ML++Ab++AC2v34DO53Nizxf2jNkzZs/Ya8+7XroBA3wYAQYoEWCAEgEGKBFggBIBBigRYIASAQYoEWCAEgEGKBFggBIBBigRYIASAQYoEWCAEgEGKBFggBIBBigRYIASAQYoEW
                               CAEgEGKBFggBIBBigRYIASAQYoEWCAEgEGKBFggBIBBigRYICSU5ItSbZt2x2s67p7Pno+n0mSaZqORxX3+z2x51v2jNkzZs/Yu17O87x7XpYlcQMG6PnxDfh2ux1fVVyv1yTJ
                               4/E4HlXYM2bPmD1jn7rncrkcj3bcgAE+zK9vwK8vQMvrN6Dz+ZzY84U9Y/aM2TP22vOul27AAB9GgAFKBBigRIABSgQYoESAAUoEGKBEgAFKBBigRIABSgQYoESAAUoEGKBEgA
                               FKBBigRIABSgQYoESAAUoEGKBEgAFKBBigRIABSgQYoESAAUoEGKBEgAFKBBigRIABSgQYoESAAUoEGKDklGRLkm3bdgfruu6ej57PZ5JkmqbjUcX9fk/s+ZY9Y/aM2TP2rpfz
                               PO+el2VJ3IABen58A77dbsdXFdfrNUnyeDyORxX2jNkzZs/Yp+65XC7Hox03YIAP8+sb8OsL0PL6Deh8Pif2fGHPmD1j9oy99rzrpRswwIcRYIASAQYoEWCAEgEGKBFggBIBBi
                               gRYIASAQYoEWCAEgEGKBFggBIBBigRYIASAQYoEWCAEgEGKBFggBIBBigRYIASAQYoEWCAEgEGKBFggBIBBigRYIASAQYoEWCAEgEGKBFggBIBBig5JdmSZNu23cG6rrvno+fz
                               mSSZpul4VHG/3xN7vmXPmD1j9oy96+U8z7vnZVkSN2CAnh/fgG+32/FVxfV6TZI8Ho/jUYU9Y/aM2TP2qXsul8vxaMcNGODD/PoG/PoCtLx+Azqfz4k9X9gzZs+YPWOvPe966Q
                               YM8GEEGKBEgAFKBBigRIABSgQYoESAAUoEGKBEgAFKBBigRIABSgQYoESAAUoEGKBEgAFKBBigRIABSgQYoESAAUoEGKBEgAFKBBigRIABSgQYoESAAUoEGKBEgAFKBBigRIAB
                               SgQYoESAAUpOSbYk2bZtd7Cu6+756Pl8JkmmaToeVdzv98Seb9kzZs+YPWPvejnP8+55WZbEDRig58c34NvtdnxVcb1ekySPx+N4VGHPmD1j9ox96p7L5XI82nEDBvgwv74Bv7
                               4ALa/fgM7nc2LPF/aM2TNmz9hrz7teugEDfBgBBigRYIASAQYoEWCAEgEGKBFggBIBBigRYIASAQYoEWCAEgEGKBFggBIBBigRYIASAQYoEWCAEgEGKBFggBIBBigRYIASAQYo
                               EWCAEgEGKBFggBIBBigRYIASAQYoEWCAEgEGKBFggJJTki1Jtm3bHazruns+ej6fSZJpmo5HFff7PbHnW/aM2TNmz9i7Xs7zvHteliVxAwbo+fENGIB/xg0Y4MMIMECJAAOUCD
                               BAiQADlAgwQIkAA5QIMECJAAOUCDBAiQADlAgwQIkAA5QIMECJAAOUCDBAiQADlAgwQIkAA5QIMECJAAOUCDBAiQADlAgwQIkAA5QIMECJAAOUnJJsSbJt2+5gXdfd89Htdju+
                               qrher0mSx+NxPKqwZ8yeMXvGPnXP5XI5Hu3M87x7XpYlcQMG6Pn1Dfj1BWiZpilJcj6fE3u+sGfMnjF7xl573vXSDRjgwwgwQIkAA5QIMECJAAOUCDBAiQADlAgwQIkAA5QIME
                               CJAAOUCDBAiQADlAgwQIkAA5QIMECJAAOUCDBAiQADlAgwQIkAA5QIMECJAAOUCDBAiQADlAgwQIkAA5QIMECJAAOUCDBAiQADlJySbEmybdvuYF3X3fPR8/lMkkzTdDyquN/v
                               iT3fsmfMnjF7xt71cp7n3fOyLIkbMEDPj2/At9vt+Krier0mSR6Px/Gowp4xe8bsGfvUPZfL5Xi04wYM8GF+fQN+fQFaXr8Bnc/nxJ4v7BmzZ8yesdeed710Awb4MAIMUCLAAC
                               UCDFAiwAAlAgxQIsAAJQIMUCLAACUCDFAiwAAlAgxQIsAAJQIMUCLAACUCDFAiwAAlAgxQIsAAJQIMUCLAACUCDFAiwAAlAgxQIsAAJQIMUCLAACUCDFAiwAAlAgxQIsAAJack
                               W5Js27Y7WNd193z0fD6TJNM0HY8q7vd7Ys+37BmzZ8yesXe9nOd597wsS+IGDNDz4xvw7XY7vqq4Xq9JksfjcTyqsGfMnjF7xj51z+VyOR7tuAEDfJhf34BfX4CW129A5/M5se
                               cLe8bsGbNn7LXnXS/dgAE+jAADlAgwQIkAA5QIMECJAAOUCDBAiQADlAgwQIkAA5QIMECJAAOUCDBAiQADlAgwQIkAA5QIMECJAAOUCDBAiQADlAgwQIkAA5QIMECJAAOUCDBA
                               iQADlAgwQIkAA5QIMECJAAOUCDBAySnJliTbtu0O1nXdPR89n88kyTRNx6OK+/2e2PMte8bsGbNn7F0v53nePS/LkrgBA/T8+AYMwD/jBgzwYQQYoESAAUoEGKBEgAFKBBigRI
                               ABSn78d8C32+34quJ6vSZJHo/H8ajCnjF7xuwZ+9Q9l8vleLTj74ABPsyvb8CvL0DL678FP5/PiT1f2DNmz5g9Y68973rpBgzwYQQYoESAAUoEGKBEgAFKBBigRIABSgQYoESA
                               AUoEGKBEgAFKBBigRIABSgQYoESAAUoEGKBEgAFKBBigRIABSgQYoESAAUoEGKBEgAFKBBigRIABSgQYoESAAUoEGKBEgAFKBBigRIABSk5JtiTZtm13sK7r7vno+XwmSaZpOh
                               5V3O/3xJ5v2TNmz5g9Y+96Oc/z7nlZlsQNGKDnxzdgAP4ZN2CADyPAACUCDFAiwAAlAgxQIsAA/5J5nr/8BcTfCTBAyelv/96S5K+//kr+w9+tAfDf4e+AAcr+fgN+2ZLkzz//
                               PL4H4BdeN99Xe92AAUr+0w34Zf8/hwDgt3bNdQMGKPlfdTLdbhqWqUkAAAAASUVORK5CYII=
                               """;

    public const string DefaultIcon = """
                                      
                                      iVBORw0KGgoAAAANSUhEUgAAAQAAAAEACAYAAABccqhmAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsEAAA7BAbiRa+0AAAGHaVRYdFhNTDpjb20uYWRvYmUueG1wAAAAAAA8P3hwYW
                                      NrZXQgYmVnaW49J++7vycgaWQ9J1c1TTBNcENlaGlIenJlU3pOVGN6a2M5ZCc/Pg0KPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyI+PHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3Lncz
                                      Lm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj48cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0idXVpZDpmYWY1YmRkNS1iYTNkLTExZGEtYWQzMS1kMzNkNzUxODJmMWIiIHhtbG5zOnRpZmY9Imh0dH
                                      A6Ly9ucy5hZG9iZS5jb20vdGlmZi8xLjAvIj48dGlmZjpPcmllbnRhdGlvbj4xPC90aWZmOk9yaWVudGF0aW9uPjwvcmRmOkRlc2NyaXB0aW9uPjwvcmRmOlJERj48L3g6eG1wbWV0YT4NCjw/eHBhY2tldCBl
                                      bmQ9J3cnPz4slJgLAAAiCklEQVR4Xu2d37NlVXHH+0xu5BqZRJSLP4CxZPwBo2JitKxYo6gDaFLJn+JLKiL4mIcUiOYl/iFW+aaO+BOjWJYiIirM4FygZAYjZqbKizWplYf1q7tX91prn3NRZs73Q53L3d3fXm
                                      vtPd2999nnxyUCAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAPwZWWkDEdFTTz4ZHn/8Z7S/f44unD9PBwd/0BIAwCuYa48epb29G+jmm4/R7e99L914401mrQvj+eefD9/8
                                      5kP06E9+TJcvX+YuAMAVyu7uq+nEiXfRh06ebBpB2fjFL54Ip7/2Fdo/d477AQBXCbfccpxO3XkX3XL8baXuV0REZ556Mpz+2lfpzJmnRAAA4OXn7e+4ld7xzlvL9i9/8QT96pdPHJqfc/OxY3Tqzrvpne+8dU
                                      VEdOTZZ58J3/nOt1H8AGwB++fO0Y9++Aidf/75QER05OyZM3T2zBmtAwBcpTz++M/oJ4/+mIiIjpw58xTu8gOwRVy+fJn2z52jX//66bD6z88/EC5cuKA1AICrmOv39ujUnXfTkYsXL2kfAOAq59LFS3Tp4kU6
                                      gst/ALaPg4M/0MHBH2h132f+LWTj7u4u/e3fvY8+8IEP0muvu452dnZkFADgiuOFCxfoe9/7Lj3200fp4OCg2E/deRcdyRu7u7t08sN30F13f5Ku39tD8QNwlXD93h794z/9M5388B20u7srfKUBvO3t76Dbbj
                                      uBwgfgKmRnZ4fe857b6dbbTgh7aQDXX79H1+/tCScA4Orh2qNH6dprjwpbaQAAgKubnZ2d5gofDQCALQYNAIAtBg0AgC0GDQCALQYNAIAtBg0AgC0GDQCALQYNAIAtBg0AgC0GDQCALQYNAIAtBg0AgC0GDQCA
                                      LQYNAIAtBg0AgC2mfCfgRz92ij728VPaP+Sxxx6jH/3oR/THP/5Ru15xvOpVr6L3ve999O53v1u7pnn4uZfoiz++RN977iV66f/K1yluRig/hoQi6+hdl+EwTDZRWOcfMC1MzOyXMew1O0R//8Zr6FPvfy19/C
                                      1/JZ2TbFMOP/T10/SNh04T6e8EBGMe2j+g//j+/9I39g82K/6QMjk/OknPZTH5+3rb5cQYpkjWx0cIgc3fQyx0TJmCz2dImmGr/qXLgR5+5oD+65EX6bvP4Buul7LxFcA28cUfX6Qv/PDiesUvktcne/Ofb5VJ
                                      n30rCnnbHc5wGKZI65ir4WCFjpkbXMn6Mdf8xYo+/cHr6FMfeK12AQauADbgpcthWfGHlMWdM1xGy+JZ14hLPm0uTu7gm402Ex38LDuuzyzUdoMy/9zgUjZYPHO/dDnQwZJ/G0CEm4AvAzzhvcTtFpwR59YBdx
                                      gxJjKmnb9DWbB2GISkt9bGaI/DIKZxV0P5o/dgGjSAQ6Imn5+8uSZqwfFsNuIMU8RwdIaxHDOFv8r7NRLruUvh+9gFb8SY7saQrEY86IIGsAk52fPlulEk4uzWJLyD6TbiDJN2BHaWF2vpwfYpPg0ZkeaL3UI7
                                      BXJ+RzvcL8dsuEAfNICltBVtkiUzVwYigYvEMBqmiuNodJqF3SEQ06bfi0/G6mGju7NOw2w6uKnRgyWgASym80wzJSRP9HhZamSpmcCm0TRVqlMXW7eWeRHPUAbkAXawnJvvE9M75tbpmySuA3RAA1iMTDRRcE
                                      R+wVMvibORNRdXm0mzWXVpwauy2xkSgcUM9OIYBOov3jRzvXIapgqLcTWgBxrAAnSih3KJ7ySv63ISPpQuYhAd+Xm5rkszhNii+baHWJKv40PW4Yz90eZmSG5Mza+rp8ZZ/i20DEyBBrAWNQndO89NAhtZPZns
                                      VsEPWRIQkr6/GKIsE787esccMZxuFbfrKkVv6sES0AAWYSQuN8s8tQzS7JIFq5LknTsPsiJmKqOZv69vhx3sVzO2ehgmSeto1wAOAzSAdegmL9mOCb2+vOcvwTVh61RE0adHJ54Pvyov77k7YJgNrWFqSQI2v7
                                      PECBd1hcACDeDQUAXCN828rM753F2Q6MP5JbKOZHDzXgA9drCMhrYhjV/er8Can5Zab7bS6wKLQQNYiplzKWMnkr0k/Wwti8rUToOQYvSCjInkGjqL18OZjrFZU+ae0FKW5OMwoQdjNv404DZ9lvrzj/yevvDI
                                      77V5kIzRadRfhySeiSmaGXFErsWJc8wRw2mYKtU5fxxYw1utpgI//Q+vo09/6PXaPGSbchifBjwsAnu4jjUv781xFUXTF/OzfHzI9TU0Zm5onKap0jqtm5mNLR8Dvu3Bdw4sZuMrgG2iXAE0uVYN83moknyGUH
                                      4MkevoxGTXSsucGMcckc7ZY7Gi3JgWYByLT3/o9WtdAWwTuALYhKBzLhqWnYTYWX6GkCqpnLl95Dqy3onRLiuGb2p9QTr5UuOrBxZJkMTD4i9T8GM3iAFToAEsQlYDL3o314lEsk/n7WTRZ2QNOTF8+X1js9mi
                                      X7KUawjNmtg+GdOZlEF0QLtWPT+YAw1gIVayU5uSNWlzwo8oeW4MrtBF131e75gbY2eICnO6Go7THXoEYvpODB86G3p6YIIGcNjwrOzlYyk2nux+gK4j+RkELlQPz+HqOFmrz/buG6ArtTLHiJ2bCGqKfiIGmK
                                      ABbEQtEFGdHiVf+4nLh6vD8hj2GQRpdlAOV5dJc+T5tbvBXLBPUDvZQwybGpG1s4NhgA0awCYYeWhSdP0Aqx5W8RMB0siHETcfskM/2k2J1FvraOGVqX0GZXh3EZHkrkPXdcVj4ewyWAs0gCXkBO5VCE/0ovOz
                                      tB2O6/ObZJWr2dYO5W9cag69VA8u7OmIDz8+BqTmjv/z9fZwthb0QQM4TOzMFIgaKrJOnOsyHNzU6Ek4+Br4y3V2mFhsnzKFu4hK6SVRW9udikumdhmGFiwCDWBdcu6FcYG0Bd+5iZcxXXxSvQatzUgBX0eu+3
                                      bpZpeyKcNnbWcx3MUKX1/Wl201VNXpOUJrAlOgAaxNP9n9+okx5n30ZkhuUHojPFL1vdfps1JsFaFw2AQaF3yGDRvyuliMGIH1kdoUSqTQiQdYCzSApViVxGjdTqZqs5nZDFOrqY7OEiWzRS/m7y4iwvRR2Ykx
                                      9qt5OsDndoYBy0EDWESbeaV+ROEbGe2auXFGb9Ge7X3SgGOhmn9yMUyf/1vpv9rDh2qGM4yNxsKIA0PQANYgkFU/bUaXpF+Sm+0wBlFQXhfvaqkOmM+ePb2Yf2IxTOK9Rh+IXTSYQ0nniohW0/rZYwAsNv404D
                                      Z9lvrB//4dff77LzKLk3WOOaKcXS0nCnuJvhLDLbhULrqJgDRsuYHYi3FdhsMwSaTAOg73nLye7jm5p81DtimH8WnAjQnsIVnJC12GivGHSFQBP8tbSc8JxJ+PaK9ByJXUXQzxYYko/XFycUuuooaTd/jVPMOp
                                      q6Ds1sRxAPNsfAWwTcQrgN+V7VWunwbTGHFd0mGPq1Ci1Wo199FafxGVJIn/iz/rWV++bEftUvw5HHMlzZh03pcBNVc7RHTPyb21rgC2CVwBHAYhPtrETA7LZLi0Y+oM1xGZxR90jKGhuj/lQVSez+ezeInWw4
                                      khsyG1CK5xpuYCvWvWLlFZh1hsZ3zggQawlCbJjOwzTBXpFLXpkvR9UaVM4S5CkmqobKjFly1juGhSMXnu4dRLXr3IY86KwQxoAIvgia4TXppaqnM6h4uwN643dy8gUWLMASrMtVrpd+PVmBWt4t17Fx4T90s/
                                      lWiZPVhgHdAANqFTMzzR1z7LzRDyj1xUzqLEyTOtybuVp+qUys28Gmdpo09TBXzX+n1NiXqU4f3RgA8awBJ4UZi5Zif7mBQ3I+YJP5P0rI5yEZuw/apn+eoQZc+0NlUwfRx0Z5ih7P9sANCgASzB/JbL+WQXRa
                                      UT3okhsgquIy7DxrM1laKXRZxv7K0ovemG0byhh8/vTl0F3nFoj54jNLWkjlkbA5aDBrCEknQ50f1ktwhFrD0GpZ509RnBzCUKN66ybPGCF7WkBzE2bcTEw+MgXIPjUFxlCl88tVRgggawmFRis9k22yF4Fgdu
                                      mCWWei5y5XLeWpvfp8+MjYYjF9k2EWNuItVtZo9F1nUXRJTnHMuAARrAQkpOuixIdIEsroamhmrl8bN8iVZDydGrY77OpN7btWoeCDNyYTMHuDkO8amO+sARmAIN4FDgGal9DjKLtbfC3Plsnc/YMe1ZLC8kZq
                                      wxzJl/daum6vlTnS5in7RTEZJerCsHtYviBd/qk0ZsgRnQANbGSPbVilbWjcKSr+OCFzUUKF3WxwF02pcbeE0tVGNeTZBmKRUb6TFeKtMOhRExf08ffWLYsqPUfuZC7xOYBg1gEUbRC3e98x63UxbPZGiSxJfg
                                      ZAyP5kXfLoMpucadvs6jb2ia8gwXdYUJsQg/qJl/FW9exKc7TEdsbnsoMAkawCJWzkuBBn7VRXiyF1kqRCbLBZ8f2Rlv9jlF1Zk2UvVyfgcuGor5kmYGr1K2VbuADrds1jEAU2z8acBt+iz1gw//lh783v9oc8
                                      q7yeRLslzmsZ2smKWS725Lu1bZph7iKqVLM7lN0YzF5qFa0bhRCLetvecjN9BnPvIGbR6yTTmMTwMeNhNn+vyIJ7W4wZ+b87v4PCafBMUghs6GOct3CsSHfw2jLkvcsRMhjj1YiPSmX+KFVPJYxc+HDdxgMF4C
                                      cNj4CmCbePDh39KDD/9Wm21Y8YobcQr7LJ+MnU0bJjLHdLAK0KNI52JC+ZGey/TCej7tNLT3fOQG+swdy68AtglcAbyclJNnflNOp/hD1VN5KpCMTF1u+nWRMcOTNz/LzyD0ci5NYPKyUe5aaqF6CJSzqyXPCA
                                      agAWwCq4tYdG3Ri3xtDK6xmOxiltUg1uB+xNYper1NajmW30AUfV5XHoQPwcc2YYK6iw5VMLlMoEADWEBJ8EDlLK+zNOdhvEs/fp2+bLVDKaKjebnO0FZTGiyYXaRFVLEzeEIsd7R416Xj0jpNbabVdpYJBqAB
                                      LKCeWduMywVPJIuzKlVm69w3kYKpRNeT92KC0ndopNxg4e6b4TBMkipYsntgDBrAAuI5v96xt4peZqSR2Y3GoorscRWTRVyYGjQSkrxKjX3quriROQyTJDqDKnqboQA4oAEsYJXfhJoS164jJ7MNU4XHRJHO5z
                                      Z0QdKXoef0ouACNWurQt/VMK2Ngjw/b7ImIQzGAz3QABaQz0ZtUjqZ7Zgj1ckLrlejsflkkfYaiCoeB9S5ecySfaI2Nv/ar2L2PgW5//auDg4UmAYNYA1q/qtKULkvqQ59I69PFU69gy/kqulry2rEOsyFd/aJ
                                      lJMVvNaX36UgH4s+bJF2RwBrggawGJXdOtnFmS4lebpvMFGXkSXJzgcOfCE2QlH0Rpxjlg7mNLWZVj93LCaPAfXmBj3QANahzWfmk0616aDOcDNMFjwxaRAbRpy7VsPBTY2eGieflk9tPpUSC3YQ87uLAAPQAJ
                                      bQzbPsXJmJ3iAqQjsdRMLbcEkcmlWKFcfcNswxpTXu3Jv3TaJerq83Np+fL6QXAEagAWxEm4Td5+lTnUGhK8lJ+OIREqe5dIfiziRwtZkoCMSW2Xi5mTW+1tlS/CMhWAoawGJSshvvyOvWdXKa3xjEmR5Q1U7I
                                      c3QqyjE3MVw31EeBVfgCsV/aaVCGV2szmDxcwGDjTwNu02epP/edC/S577ygzTbrZONkjJQNYky3aXTNnECTBUzNQvsU6XxMHT7+8pmPvpHu/dibuGSKbcphfBrwELCfzy48FQWln4jJsvyXe+w1qIdvdM2S/C
                                      pGehnS1WXm94cozz1cREEerrkY4LPxFcA24V4BTCf7nK5R9eJcl+NwzJUq6E0rmWkMjFK8nFVjM2WtobDuFcA2gSuAw2LmzB34o6NLZKmI6cWZrjJKazL1JAQzu1UoYu0wEPtjBVRblqqDYcd1XGAMGsASRBIP
                                      KBm8IDtZ5ss/0Mn9ekjTKF0m0bnsTUppwDmxWlZfL5ba/iIR44JNQAM4LPipc6I4tLx+pj77Y2HGDS/ZlZEXhquXRe9rM3yRI20ej5/p7SBxmFgM/24B402Vaqj+HGAMGsC6lLybLHgmbb9Ag8VrsxjacJg6jT
                                      OHe0NTFf2IQKrofeThSi+nOjEh/xBuY4cNE5gDDWApOdkXZFxJ5FGM6TLmMkyS6uQftrF6FbseOPSiL8tkQ08s3pA0BtMEloMGsIi5jCu5mS9prSLhCWy4TaNhqqiBypVG2mziktad36Bo+wF8l+vVhRPD5xeS
                                      xmCawGagARwC/AxXa8PJUjOBdQUkgWHyYvQaGnmGC1yRHp7vmB0kZNXS3NsQmGal70+bcJosGIIGsAY8J2PCC0tKSCdgxJRW3rmvRecxLWQ7NbWQMmz86vJBjDmsYWw0mioob8nWEjAFGsBCam3EzO++tb9JYp
                                      3s6TFMeFIxI21d31R1lKH7i+Cy2k+i1buRR2Ttm9oXbTapMXJ+sAloAIuRWRrSn9pacZeQNIaKY24Hai/xG4YCRWAx/kKImCzuo16bFhsP4VA0Oo50zu4amAcNYFPcmlNZrZPc1bfF3o6difreRYigTKEXY8Dm
                                      zuN3P+rsoo9D4Luq4A7p7E+dF6vtYAQawAJKEto5aju0TmzHjbDosjYNwAqpW5hlScbaDMo6qqW+TKjhQxZJY2g2JdLJjwN/yPcrJH27WLAQNICllGTjGW1kt2GKtAlv6zg84Wf0OUTOZaELTa5Pxbkuw2iYWk
                                      d7teOR1MuOARiy8acBt+mz1A986zx97lvPa/OCZKxvylnEkqBQfrjI4fpaIkvSGCKOOVKd1u6sVivnSqae4X1N5N6Pv5nuPfVmbQYMfBpwI1TyhdYkiYL8hqBO7kb06XDqtKi1HX0pvqzraBtJY+iaK9EZ0tze
                                      7sjCZgMys1v83flBj42vALaJB771PH3um+e1mVGz0MvVhmlhIpQfU9ThBzGm2zRGOi6OW7Qm9Ww/xDgO9556M9176kZhAxJcAWyCmZyhOGZO2hEm7L6RgA2/4AxfHyVYyyqmWxn5MKY+E531iscVVsSCtVMhDv
                                      BIDGZAA1gLWQm12CRNaVuJbsQR8eH7yR50XfSqlLuERBvTyp1hIjKmvCPP1WdEh9LOljLFhBYsBg1gMTkR6/f/2xifshuRE71o+zEhF0fc8vWuSznyZrDOxsVZYubqOOmLWPsNxLLsxfO542PiHgtoQANYCE+4
                                      9rP0PNnd3K0UTa4iLm4DdcK7k3RcEeVwddQ4+Rr6sLihVg+cHmqSdm6mbf4twAxoABsQU48lq6wVn6IbB/hJr3DM0sF+z792YvhlvS56t9iKuDc+n78tdI0taQyGBYxAA1ibNYs+jCrDKrhBDDc3MXlzVJTcGZ
                                      /e9KjTOB3Co+jchUjKW5F5jIozTGAONIBF8GTXPkVQxdHJUruGOjFNLWhDiukMofVyDb3PF6SY6YIna+dM9BpC+row85OG3X0Ds6ABLGEm2UpS9sVtTciCbDBdytD4NXyQVfzNqUtpSjEhTMyR5XnggZgNLddn
                                      4LpdBxiABrAJPO9EwvuJqAsu3kg0zrhi7K6x2Wy2s1mdYS2NZEHRE985XyzXQOwMb8Q4u9txgIWgAaxDSJk8mYQ84ZOlPET6d4dTxqE2jb/kTTnUVGefMo3YuQbb7S6+4zIcdVfBGqABLKUUvo2uCavoGxoz1z
                                      JnZ4iKfD4/zUzBU54/D95ZTLOG3IScmMbFDcxhmAp6GwxBAzgk2proZKrragyOjlMFIRV/n6TnXWIcpHbQpwwZt/zFc1dxN4aKY450naADGsCalFQt9WNmtKRxGTGGSdIK5mozCZhu1fscQmADjxqEkHUXL11l
                                      +km9oM6TlwqWs/GnAbfq+wC+8Ru6/6HfMMtE1pkSw2iYbKJwLuHLqTgW2ygmlB8uxZt+icN2YlyX43DMEbkz+hjcd9dNdN9dN0kjEODTgBvgneHEeZS7RbU0RukyjfHBb+T1z/Qsrl6HV5dGTNMdmIhL+Fd0eR
                                      cR5nB8QsPU6KlxxiuNtvjBemx8BbBNPPDQb+iBb/zGPuMZpsZoajhSMJfkSTSlZUwMbktMY8R0mUbXXKkCex0tuAIYgyuAjWDvSgvq4RubzUqrz8+l+0nPRO7YBhODt5J2jYLGNak34XHy05b2hYaaq7NfwAYN
                                      YAEh/xB5tjTZbf2gLhM50bXdIbCBe4PnYZNEvvdewZcv3I1Bmk1366zLleK6xfRtOFgIGsDaGFnnJqQ08poc1WZM9PzQ4zqUQW1x0GuoKyPiVznVVH9vcOZxzJE0z1rHYTQ2WAIawGJU9rkJKR1zSZ5JcTnhZ5
                                      iYoLiFxNkBbQquUQ6hJUrAP2LcJ8WU/dJ+xcgPTNAAltJNdGocc8me4Mk+iglc74tbibMDjlk61bY2N0RBYOvok8edGTvLza4GJkEDWEI3x+TZbXnCD8Q82QcJL+fPWiPGMEWcGL5pxlERiTO9q6V2nq42EYgN
                                      bN8eBHOgAaxFTdry30ziUkrc8phI+KIZCTXO4HXp0iacyqfNQlIF613eO3NYBDI6yigI9EADWExNuJKLwxxkCT+LOH3acaKXBGKf+jP0jZkblLM/bXHmxucVfXmzUGFB4yNjB50gb34wBg1gIb2Er6RkLWI3dy
                                      Ol4MaD2xJjgjKmdmlD+t3UaqJgUI+JenUkjkMPseaRWB+H3PzAEtAAFjFIsNmCJ5bkpZL8AFn0okrS9/pwsTeU43DMkeiMZ/qZy3u2Nr7MHoGM42AH8fnlR4utb2gGM6ABLIQn2YpYVvYrI1Ly1U/yjKiLapEi
                                      PpTpNhyevuxYdYq6HLKg6Cnr5sT1OOR1tTEhTQ+WgQawkPSilpuIJqKS/Jgsk3VhxHSH6jgNUyROql/F8CjvFOTijp6IL6vZQYGWxXX4+p4LjEEDWELJzomkG1SSnejVEy9p2XcFuvM6i9JmEVeN/EbemNoo2n
                                      UYBFIFbweJY5Aecd+dmP5wYAEbfxpwm74P4P7Tz9H9X39OmyMlGeeyUhZ8h8atDatq0y5B65wvevYUoRcjfL6w3XVfS9RzS8d9nzhGn/3EMWEDEnwa8OWgc4YrHnaWi4Vn64l4kGuo5LOx4eJx9hos2Fx5bK/4
                                      i1Sf5bVQecQC4v9X+haeO5ThMExgjo2vALaJ+08/R/efflabG0oeNgnZGIj4ObxxN4aK66oOv8gtJi/rOZMTaFncXyfWMUeY09Dd94lj9NlP4gqgB64ADg37RSdxIuQ3zHTyskeJaZwMFeM5A43O8Bk2eT7Tj+
                                      CDDyaoMr3w9N4AIR7vV1yrpwPrggawCJ559XdeE7LgjWRvUEnuuUzkTTzZSCySYFC8BbG0/uB8Dbno7RaZMPdNTNiaTIwYMA0awBrIZC9WIqvgdX4Kt5Gwpk5TX7Kj0nQ8+GLZuL05ArGC94XeMahbLM4czjSa
                                      Jkl0Ns0PLAYNYAF2sjuZapqNGK5r9Jmc7KzwhVc3ATVHfE1xTCBW+Da64MynOJzGpdY2MFeqoMzvasEsaAALqHVkZJ6ZkDyrnYTn22KDF732t6Rn//Ghp7XihW9cUVGiB5y44mmMjtaEzYMz/csCGsACcsorg0
                                      zgQHYxcW03iaPTGqKFDTgzdl5bU8gtVZrf8WjrCqbENDpmaVx8eR/SMQCLQANYhyaBs6FxmKYKi1FvxfVRZ+vu+Nk/PsMTk1Wpo2fLlvObRtcsnWlr+E7DpOeL7R8w0AENYCki14yM7iY7CafI31XvqTpPemly
                                      WVz0euFGnGl29I65Ip3zdbzqjAmWggawmE5mG6ZIjfFOWrm2WUmw6uyNzfAGZwRT5uvb3eUGvRO2OSLjyvxquebNTL7gzr6B5aABLIIln66DJi9Toi++a82KfkSZe1wYdQ160Uac6WoM0my4ItVp1bAOS8p6DL
                                      QAHCpoAEuYTna76O0wLhoUPp9fFLJNlsWC62vF2KbDMDXaTBVYRd/CBsyFD/4koAEswXyCfgjJHshPfO7nsR1ZfNQOZC6brOH0HHx9WqvJNzFnj0NGzQH+pKABLCHkH/Gx7PKeiWb0RTMWV1ldm/Sz7UbSGCqG
                                      qcLj4nEYk/S8Q0zFgZcLNICFBGJnN1VXNvpMr/2MZnBbzGVR6muJ2FBF0hgkHVdxqjq2yVp1DMArBjSApQwT2Eh6D16HoyJOkirjwVrYcyuD1pr6+pjZLSIU/JUCGsCamC9X0YKkL5XsB/AzbDzL9vWtS8+RnI
                                      NhuEDMH4hWbMfrr8k51x3AKwg0gLVI74HnCe8VFLcH4tXcJUumPn/QzN0YKo450r+Jl5dftOUYjMb9E+He7QQeaACLSJk+k/BCw06hDrzo+Lvy8n9VqMfWOFo3xnfm5mPWlR3y5+WVtp4rADSARZilUOG1VCrH
                                      zkpe7CHwb8Ct+jJb6zIcE1cjRMXJ33PfPeNHte5QRbPizwnAFQcawBJygVmws7aoKqHhhSmrtBk2hwuHmkObTare+rCRG5YX0NtnonS1Aq5U0AA2wTgjckrphVgo+WLeLZqmtrlBxTjmSHXW+bXGYq7owdUDGs
                                      ACrtk5Qrs7R+Yrqui4diLOq+zJoidvahMmGmpfuVyzc4Su+Uuk81JwxBbwgbdcS+8/9hptJmIFVx+dauK1KuqWV2x6bi38mujgtwnHvYkNmM/0IQVewdx+02vo9hvtfxvggwawgA8f/xv614/dSCeP/zVds3NE
                                      FLxRzS2Ny4nJBekME1FvQ54tfGO6K5lrdo7QnbddR//+L2+lu257nXaDAfjDIABsEfjDIACAAhoAAFsMGgAAWwwaAABbDBoAAFsMGgAAWwwaAABbDBoAAFsMGgAAWwwaAABbDBoAAFsMGgAAW0xpAAcHB3RwcC
                                      C9AICrhksXL9KlSxeF7cju7quJiOiFC+fpwoXzwgkAuHq4dOkSXbp0iYiIrj16lK49epSOHD16LRERvfDCBXrhhQsqBABwtXD27Bl6+uwZIiLa3d2l3d1X05HXXhe/ROHFF1+kx376KO3vn1NhAIArnf39c/Tk
                                      k78sT/P39m6gvb09OnLs2DHa2dkhIqKnz56lx376KF26KJ8nAACuXC5dvEiP/fRRevrsWaJ09r/lluN04403rY7cedcnVidOvIuIiC5fvkw/fOQH9OUvfwlXAgBcBezvn6Mvf/lL9MNHfkCXL18mIqK33nKcTn
                                      74IyvK3zz5iyd+Hk5/7aui6Hd3d+nW207Qu99zO73xjW+io0ePFh8A4JXLwcEfaH9/n574+eP05K9+SS+++GLxvfWWW+jUnXfT8eNvqw2AiOipp54Mp7/2FTp7Jt4kAABcXdx88zE6defd9M5bby11L/6u07PP
                                      PhMe/u636fGf/QzvCQDgKmFnZ4duf+976Y47Pk43vOENoubNP+z27LPPhEcf/QntnztHF86fb948AAB4ZbO7+2rau+EGuvnmY3TixLvo+NviJT8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
                                      AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABXLf8P/sZC+5nlRg4AAAAASUVORK5CYII=
                                      """;
}
 
#region 快捷方式的信息。
 
/// <summary>
/// 快捷方式的信息。
/// </summary>
public class LinkFileInfo
{
    internal LinkFileInfo()
    {
    }
 
    public LinkFileInfo(string targetPath, string arguments = null, 
        string description = null, string iconLocation = null) 
    {
        this.TargetPath = targetPath;
        this.Arguments = arguments; 
        this.Description = description;
        this.IconLocation = iconLocation;
    }
 
    public string Arguments { get; set; }
 
    /// <summary>
    /// 设置备注。
    /// /// </summary>
    public string Description { get; set; }
 
    /// <summary>
    /// /// 键代码（KeyCode）和System.Windows.Forms.Keys相同。位屏蔽为 0x000000ff。
    /// 修饰符（Modifiers）和System.Windows.Forms.Keys不同。位屏蔽为 0x0000ff00。
    /// <para>示例：</para>
    /// <![CDATA[
    /// Alt = 1 << 8
    /// Control = 2 << 8
    /// Shift = 4 << 8
    /// WindowsKey = 8 << 8
    /// Keys.Alt | Keys.Control | Keys.Shift | Keys.F1
    /// = (short)(((1 | 2 | 4) << 8) | (int)Keys.F1)
    /// = (short)(((1 | 2 | 4) << 8) | 112)
    /// ]]>
    /// </summary>
    public short Hotkey { get; set; }
 
    /// <summary>
    /// 设置图标路径。
    /// </summary>
    public string IconLocation { get; set; }
 
    /// <summary>
    /// 设置图标ID。
    /// </summary>
    public int IconLocationId { get; set; }
 
    /// <summary>
    /// 目标路径。
    /// </summary>
    public string TargetPath { get; set; }
 
    /// <summary>
    /// 设置运行方式，默认为常规窗口。
    /// https://learn.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-showwindow
    /// </summary>
    public int WindowStyle { get; set; } = -1;
 
    public string WorkingDirectory { get; set; }
}
 
#endregion

#region 快捷方式类
 
[Obfuscation]
[ComImport]
[Guid("00021401-0000-0000-C000-000000000046")]
internal class ShellLink
{
}
 
/// <summary>
/// https://learn.microsoft.com/zh-cn/windows/win32/shell/links
/// </summary>
[Obfuscation]
[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("000214F9-0000-0000-C000-000000000046")]
internal interface IShellLink
{
    void GetPath([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cchMaxPath, IntPtr pfd, short fFlags);
    void GetIDList(out IntPtr ppidl);
    void SetIDList(IntPtr pidl);
    void GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName, int cchMaxName);
    void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);
    void GetWorkingDirectory([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, int cchMaxPath);
    void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);
    void GetArguments([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, int cchMaxPath);
    void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);
    void GetHotkey(out short pwHotkey);
    void SetHotkey(short wHotkey);
    void GetShowCmd(out int piShowCmd);
    void SetShowCmd(int iShowCmd);
    void GetIconLocation([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath, int cchIconPath, out int piIcon);
    void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);
    void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, int dwReserved);
    void Resolve(IntPtr hwnd, int fFlags); 
    void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
}

#endregion
class MyPictureBox : PictureBox
{
    public string? Path
    {
        get;
        set;
    }

    public string? Desc
    {
        get;
        set;
    }

    public string? Icon
    {
        get;
        set;
    }
}
public partial class Form1 : Form
{
    private readonly MyPictureBox[,] _pictureArray = new MyPictureBox[10, 9];
    private JsonObject? _root;
    public Form1()
    {
        InitializeComponent();
        Load += Form1_Load;
        FormClosed += Form1_Close;
        DragDrop += Form1_DragDrop;
        DragEnter += Form1_DragEnter;
    }
    [DllImport("shell32.dll")]
    public static extern IntPtr ShellExecute(IntPtr hwnd, string lpszOp, string lpszFile, string lpszParams, string lpszDir, int fsShowCmd);
    public static LinkFileInfo ReadLnkInfo(string linkFilePath)
    { 
        LinkFileInfo? info = null;
        if (File.Exists(linkFilePath))
        { 
            try
            { 
                info = new LinkFileInfo(); 
                var shortcut = (IShellLink)new ShellLink(); 
                var persistFile = shortcut as IPersistFile;
                if (persistFile != null)
                { 
                    LoadPersistFile(persistFile, linkFilePath);
                    int builderCapacity = 4000;
                    StringBuilder builder = new StringBuilder(builderCapacity); 
                    shortcut.GetArguments(builder, builderCapacity); 
                    info.Arguments = builder.ToString();
                    builder = new StringBuilder(builderCapacity); 
                    shortcut.GetDescription(builder, builderCapacity); 
                    info.Description = builder.ToString(); 
                    short pwHotkey; 
                    shortcut.GetHotkey(out pwHotkey); 
                    info.Hotkey = pwHotkey; 
                    builder = new StringBuilder(builderCapacity); 
                    int piIcon; 
                    shortcut.GetIconLocation(builder, builderCapacity, out piIcon); 
                    info.IconLocation = builder.ToString(); 
                    info.IconLocationId = piIcon;
                    builder = new StringBuilder(builderCapacity); 
                    var pfd = IntPtr.Zero; 
                    //const int SLGP_SHORTPATH = 0x1;
                    //const int SLGP_UNCPRIORITY = 0x2;
                    const short SLGP_RAWPATH = 0x4; 
                    //const int SLGP_RELATIVEPRIORITY = 0x8;
                    shortcut.GetPath(builder, builderCapacity, pfd, SLGP_RAWPATH);
                    info.TargetPath = builder.ToString();
                    int piShowCmd;
                    shortcut.GetShowCmd(out piShowCmd);
                    info.WindowStyle = piShowCmd;
                    builder = new StringBuilder(builderCapacity);
                    shortcut.GetWorkingDirectory(builder, builderCapacity);
                    info.WorkingDirectory = builder.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot load lnk path!!");
            }
        }
        return info;
    }
 
    private static void LoadPersistFile(IPersistFile persistFile, string linkFilePath)
    {
        try
        { 
            const int STGM_SHARE_DENY_NONE = 0x00000040;
            persistFile.Load(linkFilePath, STGM_SHARE_DENY_NONE);
        }
        catch (Exception ex)
        { 
            throw new Exception("Cannot load persist file!!");
        }
    }
    private static MemoryStream Base64ToStream(string s)
    {
        return new MemoryStream(Convert.FromBase64String(s.Replace(" ", "").Replace("\n", "")));
    }

    private void Form1_DragDrop(object? sender, DragEventArgs e)
    {
        var dragFile = (Array)e.Data!.GetData(DataFormats.FileDrop)!;
        if (dragFile.Length > 1)
        {
            MessageBox.Show("你无法一次性拖入两个或以上文件。", "操作无法完成", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        var path = dragFile.GetValue(0)!.ToString();
        var cc = this.PointToClient(new Point(e.X, e.Y));
        var ids = 0;
        for (var i = 0; i < 10; i++)
        {
            for (var j = 0; j < 9; j++)
            {
                if (cc.Y > _pictureArray[i, j].Top &&
                    cc.Y < _pictureArray[i, j].Top + _pictureArray[i, j].Height &&
                    cc.X > _pictureArray[i, j].Left &&
                    cc.X < _pictureArray[i, j].Left + _pictureArray[i, j].Width)
                {
                    var pic = _pictureArray[i, j];
                    var id = Convert.ToString(ids);
                    if (!String.IsNullOrEmpty(pic.Path) && _root!.TryGetPropertyValue(id, out JsonNode? _))
                    {
                        MessageBox.Show("该格子已经有文件了，请右键删除掉该文件再拖入吧~", "无法拖入", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Path.GetExtension(path) == ".bat")
                    {
                        pic.Path = path;
                        pic.Icon = "";
                        pic.Desc = "";
                        pic.Image = Image.FromStream(Base64ToStream(SomeConst.DefaultIcon));
                        _root!.Add(id, new JsonObject());
                        (_root[id] as JsonObject)!.Add("path", pic.Path);
                        (_root[id] as JsonObject)!.Add("desc", "");
                        (_root[id] as JsonObject)!.Add("icon", "");
                    }
                    else if (Path.GetExtension(path) == ".lnk")
                    {
                        var c = ReadLnkInfo(path!);
                        pic.Path = path;
                        pic.Icon = String.IsNullOrEmpty(c.IconLocation) ? c.TargetPath : c.IconLocation;
                        pic.Desc = String.IsNullOrEmpty(c.Description) ? GetExeDesc(c.TargetPath) : c.Description;
                        pic.Image = Image.FromStream(GetFileIconStream(pic.Icon));
                        _root!.Add(id, new JsonObject());
                        (_root[id] as JsonObject)!.Add("path", pic.Path);
                        (_root[id] as JsonObject)!.Add("desc", pic.Desc);
                        (_root[id] as JsonObject)!.Add("icon", pic.Icon);
                    }
                    else if (Path.GetExtension(path) == ".exe")
                    {
                        var c = GetExeDesc(path!);
                        pic.Path = path;
                        pic.Icon = pic.Path;
                        pic.Desc = c;
                        pic.Image = Image.FromStream(GetFileIconStream(pic.Path!));
                        _root!.Add(id, new JsonObject());
                        (_root[id] as JsonObject)!.Add("path", pic.Path);
                        (_root[id] as JsonObject)!.Add("desc", pic.Desc);
                        (_root[id] as JsonObject)!.Add("icon", pic.Icon);
                    }
                }
                ids++;
            }
        }
    }

    private string GetExeDesc(string path)
    {
        if (File.Exists(path))
        {
            var info = FileVersionInfo.GetVersionInfo(path);
            if (!String.IsNullOrEmpty(info.FileDescription))
            {
                return info.FileDescription;
            }
        }
        return "";
    }

    private void Form1_DragEnter(object? sender, DragEventArgs e)
    {
        if(e.Data!.GetDataPresent(DataFormats.FileDrop)) 
            e.Effect = DragDropEffects.Copy;
    }

    private void PictureBox_Click(object? sender, EventArgs e)
    {
        var pic = sender as MyPictureBox;
        var id = pic!.Name.Replace("Soft", "");
        if (!String.IsNullOrEmpty(pic.Path))
        {
            ShellExecute(0, "open", pic.Path, "", Application.StartupPath, 1);
        }
        else
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择你要执行的文件~";
            ofd.Filter = "*.exe;*.bat;*.lnk|*.exe;*.bat;*.lnk";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(ofd.FileName) == ".bat")
                {
                    pic.Path = ofd.FileName;
                    pic.Icon = "";
                    pic.Desc = "";
                    pic.Image = Image.FromStream(Base64ToStream(SomeConst.DefaultIcon));
                    if (_root!.TryGetPropertyValue(id, out JsonNode? inv))
                    {
                        inv!["path"] = pic.Path;
                    }
                    else
                    {
                        _root.Add(id, new JsonObject());
                        (_root[id] as JsonObject)!.Add("path", pic.Path);
                        (_root[id] as JsonObject)!.Add("desc", "");
                        (_root[id] as JsonObject)!.Add("icon", "");
                    }
                }
                else if (Path.GetExtension(ofd.FileName) == ".lnk")
                {
                    var c = ReadLnkInfo(ofd.FileName);
                    pic.Path = ofd.FileName;
                    pic.Icon = String.IsNullOrEmpty(c.IconLocation) ? c.TargetPath : c.IconLocation;
                    pic.Desc = String.IsNullOrEmpty(c.Description) ? GetExeDesc(c.TargetPath) : c.Description;
                    pic.Image = Image.FromStream(GetFileIconStream(pic.Icon));
                    if (_root!.TryGetPropertyValue(id, out JsonNode? inv))
                    {
                        inv!["path"] = pic.Path;
                    }
                    else
                    {
                        _root.Add(id, new JsonObject());
                        (_root[id] as JsonObject)!.Add("path", pic.Path);
                        (_root[id] as JsonObject)!.Add("desc", pic.Desc);
                        (_root[id] as JsonObject)!.Add("icon", pic.Icon);
                    }
                }
                else if (Path.GetExtension(ofd.FileName) == ".exe")
                {
                    var c = GetExeDesc(ofd.FileName);
                    pic.Path = ofd.FileName;
                    pic.Icon = ofd.FileName;
                    pic.Desc = c;
                    pic.Image = Image.FromStream(GetFileIconStream(ofd.FileName));
                    if (_root!.TryGetPropertyValue(id, out JsonNode? inv))
                    {
                        inv!["path"] = pic.Path;
                    }
                    else
                    {
                        _root.Add(id, new JsonObject());
                        (_root[id] as JsonObject)!.Add("path", pic.Path);
                        (_root[id] as JsonObject)!.Add("desc", pic.Desc);
                        (_root[id] as JsonObject)!.Add("icon", pic.Icon);
                    }
                }
            }
        }
    }

    private void MenuChangeIcon_Click(object? sender, EventArgs e)
    {
        var menu = sender as ToolStripMenuItem;
        var sp = menu!.Name!.Replace("MI", "").Split(",");
        var i = Convert.ToInt32(sp[0]);
        var j = Convert.ToInt32(sp[1]);
        var id = sp[2];
        var pic = _pictureArray[i, j];
        if (String.IsNullOrEmpty(pic.Path))
        {
            MessageBox.Show("你还没有为该格子添加应用程序，请左键点击添加或者右键点击添加路径或把exe或lnk拖入该格子后再次尝试修改图标~", "未添加应用程序", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        var ofd = new OpenFileDialog();
        ofd.Title = "请选择你要设置的图标~";
        ofd.Filter = "*.exe;*.ico|*.exe;*.ico";
        if (ofd.ShowDialog() == DialogResult.OK)
        {
            pic.Icon = ofd.FileName;
            pic.Image = Image.FromStream(GetFileIconStream(pic.Icon));
            if (_root!.TryGetPropertyValue(id, out JsonNode? inv))
            {
                inv!["icon"] = pic.Icon;
            }
            else
            {
                _root.Add(id, new JsonObject());
                (_root[id] as JsonObject)!.Add("icon", pic.Icon);
            }
        }
    }

    private void MenuChangePath_Click(object? sender, EventArgs e)
    {
        var menu = sender as ToolStripMenuItem;
        var sp = menu!.Name!.Replace("MP", "").Split(",");
        var i = Convert.ToInt32(sp[0]);
        var j = Convert.ToInt32(sp[1]);
        var id = sp[2];
        var pic = _pictureArray[i, j];
        var ofd = new OpenFileDialog();
        ofd.Title = "请选择你要设置的路径~";
        ofd.Filter = "*.exe;*.bat;*.lnk|*.exe;*.bat;*.lnk";
        if (ofd.ShowDialog() == DialogResult.OK)
        {
            pic.Path = ofd.FileName;
            if (_root!.TryGetPropertyValue(id, out JsonNode? inv))
            {
                inv!["path"] = pic.Path;
            }
            else
            {
                if (Path.GetExtension(ofd.FileName) == ".bat")
                {
                    pic.Path = ofd.FileName;
                    pic.Icon = "";
                    pic.Desc = "";
                    pic.Image = Image.FromStream(Base64ToStream(SomeConst.DefaultIcon));
                    _root.Add(id, new JsonObject());
                    (_root[id] as JsonObject)!.Add("path", pic.Path);
                    (_root[id] as JsonObject)!.Add("desc", "");
                    (_root[id] as JsonObject)!.Add("icon", "");
                }
                else if (Path.GetExtension(ofd.FileName) == ".lnk")
                {
                    var c = ReadLnkInfo(ofd.FileName);
                    pic.Path = ofd.FileName;
                    pic.Icon = String.IsNullOrEmpty(c.IconLocation) ? c.TargetPath : c.IconLocation;
                    pic.Desc = String.IsNullOrEmpty(c.Description) ? GetExeDesc(c.TargetPath) : c.Description;
                    pic.Image = Image.FromStream(GetFileIconStream(pic.Icon));
                    _root.Add(id, new JsonObject());
                    (_root[id] as JsonObject)!.Add("path", pic.Path);
                    (_root[id] as JsonObject)!.Add("desc", pic.Desc);
                    (_root[id] as JsonObject)!.Add("icon", pic.Icon);
                }
                else if (Path.GetExtension(ofd.FileName) == ".exe")
                {
                    var c = GetExeDesc(ofd.FileName);
                    pic.Path = ofd.FileName;
                    pic.Icon = ofd.FileName;
                    pic.Desc = c;
                    pic.Image = Image.FromStream(GetFileIconStream(ofd.FileName));
                    _root.Add(id, new JsonObject());
                    (_root[id] as JsonObject)!.Add("path", pic.Path);
                    (_root[id] as JsonObject)!.Add("desc", pic.Desc);
                    (_root[id] as JsonObject)!.Add("icon", pic.Icon);
                }
            }
        }
    }

    private void MenuChangeDesc_Click(object? sender, EventArgs e)
    {
        var menu = sender as ToolStripMenuItem;
        var sp = menu!.Name!.Replace("MD", "").Split(",");
        var i = Convert.ToInt32(sp[0]);
        var j = Convert.ToInt32(sp[1]);
        var id = sp[2];
        var pic = _pictureArray[i, j];
        if (String.IsNullOrEmpty(pic.Path))
        {
            MessageBox.Show("你还没有为该格子添加应用程序，请左键点击添加或者右键点击添加路径或把exe或lnk拖入该格子后再次尝试修改描述~", "未添加应用程序", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        var str = Interaction.InputBox("请输入你要修改的描述", "请输入描述", "");
        if (!String.IsNullOrEmpty(str))
        {
            pic.Desc = str;
            if (_root!.TryGetPropertyValue(id, out JsonNode? inv))
            {
                inv!["desc"] = pic.Desc;
            }
            else
            {
                _root.Add(id, new JsonObject());
                (_root[id] as JsonObject)!.Add("desc", pic.Desc);
            }
        }
    }

    private void MenuDelete_Click(object? sender, EventArgs e)
    {
        var menu = sender as ToolStripMenuItem;
        var sp = menu!.Name!.Replace("ML", "").Split(",");
        var i = Convert.ToInt32(sp[0]);
        var j = Convert.ToInt32(sp[1]);
        var id = sp[2];
        var pic = _pictureArray[i, j];
        if (String.IsNullOrEmpty(pic.Path))
        {
            MessageBox.Show("你还没有为该格子添加应用程序，无法删除~", "未添加应用程序", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (_root!.TryGetPropertyValue(id, out JsonNode? _))
        {
            if (_root.Remove(id))
            {
                pic.Path = "";
                pic.Icon = "";
                pic.Desc = "";
                pic.Image = null;
                MessageBox.Show("删除成功~", "删除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("删除失败，你似乎出现了bug，请联系作者修复~", "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private MemoryStream GetFileIconStream(string path)
    {
        if (File.Exists(path))
        {
            if (Path.GetExtension(path) == ".exe")
            {
                Image img = Icon.ExtractAssociatedIcon(path)!.ToBitmap();
                MemoryStream ms = new MemoryStream();
                img.Save(ms, ImageFormat.Png);
                ms.Position = 0;
                return ms;
            }
            if(Path.GetExtension(path) == ".ico")
            {
                Image img = Image.FromFile(path);
                MemoryStream ms = new MemoryStream();
                img.Save(ms, ImageFormat.Png);
                ms.Position = 0;
                return ms;
            }
        }
        return Base64ToStream(SomeConst.DefaultIcon);
    }

    private void PictureBox_MouseHover(object? sender, EventArgs e)
    {
        var ts = (sender as MyPictureBox)!;
        if (!String.IsNullOrEmpty(ts.Desc))
        {
            var tooltip = new ToolTip();
            tooltip.AutoPopDelay = 5000;
            tooltip.InitialDelay = 500;
            tooltip.ReshowDelay = 500;
            tooltip.ShowAlways = true;
            tooltip.SetToolTip(ts, ts.Desc);
        }
    }

    private void Form1_Close(object? sender, FormClosedEventArgs e)
    {
        File.WriteAllText(Application.StartupPath + @"\Soft.json", JsonSerializer.Serialize(_root, new JsonSerializerOptions
        {
            WriteIndented = true, 
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) 
        }));
    }
    private void Form1_Load(object? sender, EventArgs e)
    {
        Width = 550;
        Height = 767;
        MaximizeBox = false;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        BackColor = Color.LightGray;
        var screenSize = Screen.AllScreens[0].Bounds.Size;
        Location = new Point(screenSize.Width / 2 - Width / 2, screenSize.Height / 2 - Height / 2);
        Text = "小小软件物品栏~";
        AllowDrop = true;
        Icon = new Icon(Base64ToStream(SomeConst.Icon));
        var back = new PictureBox();
        back.Parent = this;
        back.Dock = DockStyle.Fill;
        back.BackgroundImageLayout = ImageLayout.Stretch;
        back.BackgroundImage = Image.FromStream(Base64ToStream(SomeConst.Back));
        back.SendToBack();
        var label1 = new Label();
        label1.Parent = back;
        label1.Top = 24;
        label1.Left = 12;
        label1.AutoSize = true;
        label1.BackColor = Color.Transparent;
        label1.Text = "Hint：对着图片框，左键执行，右键修改。";
        var label2 = new Label();
        label2.Parent = back;
        label2.Top = 408;
        label2.Left = 12;
        label2.AutoSize = true;
        label2.BackColor = Color.Transparent;
        label2.Text = "Hint：将外部文件拖入也可以哦！";
        back.Click += Test;
        const int cHeight = 48;
        const int cWidth = 48;
        const int cLeft = 24;
        const int c1Top = 58;
        const int c2Top = 449;
        const int c3Top = 635;
        if (File.Exists(Application.StartupPath + @"\Soft.json"))
        {
            _root = JsonNode.Parse(File.ReadAllText(Application.StartupPath + @"\Soft.json", Encoding.UTF8)) as JsonObject;
        }
        else
        {
            _root = new JsonObject();
            File.WriteAllText(Application.StartupPath + @"\Soft.json", JsonSerializer.Serialize(_root, new JsonSerializerOptions
            {
                WriteIndented = true, 
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) 
            }));
        }
        var id = 0;
        for (var i = 0; i < _pictureArray.GetLength(0); i++)
        {
            for (var j = 0; j < _pictureArray.GetLength(1); j++)
            {
                var popup = new ContextMenuStrip();
                var menuIcon = new ToolStripMenuItem();
                menuIcon.Text = "修改图标";
                menuIcon.Name = "MI" + i + "," + j + "," + id;
                menuIcon.ShortcutKeys = Keys.Control | Keys.I;
                menuIcon.ShowShortcutKeys = true;
                menuIcon.Click += MenuChangeIcon_Click;
                popup.Items.Add(menuIcon);
                var menuPath = new ToolStripMenuItem();
                menuPath.Text = "修改路径";
                menuPath.Name = "MP" + i + "," + j + "," + id;
                menuPath.ShortcutKeys = Keys.Control | Keys.P;
                menuPath.ShowShortcutKeys = true;
                menuPath.Click += MenuChangePath_Click;
                popup.Items.Add(menuPath);
                var menuDesc = new ToolStripMenuItem();
                menuDesc.Text = "修改描述";
                menuDesc.Name = "MD" + i + "," + j + "," + id;
                menuDesc.ShortcutKeys = Keys.Control | Keys.D;
                menuDesc.ShowShortcutKeys = true;
                menuDesc.Click += MenuChangeDesc_Click;
                popup.Items.Add(menuDesc);
                var menuDel = new ToolStripMenuItem();
                menuDel.Text = "删除";
                menuDel.Name = "ML" + i + "," + j + "," + id;
                menuDel.ShortcutKeys = Keys.Control | Keys.L;
                menuDel.ShowShortcutKeys = true;
                menuDel.Click += MenuDelete_Click;
                popup.Items.Add(menuDel);
                _pictureArray[i, j] = new MyPictureBox();
                _pictureArray[i, j].Parent = back;
                _pictureArray[i, j].Name = "Soft" + id;
                _pictureArray[i, j].Width = cWidth;
                _pictureArray[i, j].Height = cHeight;
                _pictureArray[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                _pictureArray[i, j].Left = cLeft + j * (cWidth + 6);
                if (i < 6)
                {
                    _pictureArray[i, j].Top = c1Top + i * (cHeight + 10);
                }
                else if (i < 9)
                {
                    _pictureArray[i, j].Top = c2Top + (i - 6) * (cHeight + 10);
                }
                else
                {
                    _pictureArray[i, j].Top = c3Top;
                }
                _pictureArray[i, j].MouseHover += PictureBox_MouseHover;
                _pictureArray[i, j].Click += PictureBox_Click;
                _pictureArray[i, j].BackColor = Color.Transparent;
                _pictureArray[i, j].ContextMenuStrip = popup;
                if (_root!.TryGetPropertyValue(Convert.ToString(id), out JsonNode? node))
                {
                    if ((node as JsonObject)!.TryGetPropertyValue("path", out JsonNode? path))
                    {
                        if (path != null)
                        {
                            _pictureArray[i, j].Path = path.ToString();
                        }
                    }
                    if ((node as JsonObject)!.TryGetPropertyValue("desc", out JsonNode? desc))
                    {
                        if (desc != null)
                        {
                            _pictureArray[i, j].Desc = desc.ToString();
                        }
                    }
                    if ((node as JsonObject)!.TryGetPropertyValue("icon", out JsonNode? icon))
                    {
                        if (icon != null)
                        {
                            _pictureArray[i, j].Icon = icon.ToString();
                            _pictureArray[i, j].Image = Image.FromStream(GetFileIconStream(icon.ToString()));
                        }
                    }
                }
                id++;
            }
        }
    }

    private void Test(object? sender, EventArgs e)
    {
        MessageBox.Show(_root!.ToString());
    }
}