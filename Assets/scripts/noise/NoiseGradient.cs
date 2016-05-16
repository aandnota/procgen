/// <summary>
/// NoiseGradient.cs
/// Author: trent (5/16/16)
/// Modified: 
/// 
/// Based on the implementation by Jordan Peck: https://github.com/Auburns/FastNoise
/// </summary>

/// <summary>
/// NoiseGradient Class Definition.
/// 
/// Gradient noise class.
/// </summary>
public class NoiseGradient : Noise
{
	public static readonly float[,] LUT_Gradient2D =
	{
		{ 0.465254262011416f, -0.885177084927198f }, { 0.999814701091156f, -0.0192500255065206f }, { 0.562013227349949f, 0.827128244157878f }, { 0.540531763173497f, -0.841323607775599f }, { -0.97869393624958f, 0.20532457024989f }, { -0.022259068317433f, 0.999752236245381f }, { -0.763453105361241f, -0.645863264100288f }, { -0.877652307360767f, 0.479297848299283f },
		{ -0.429945697678765f, 0.902854748587789f }, { -0.880336026899474f, 0.474350587374832f }, { -0.999734062007074f, 0.0230609033395389f }, { 0.961877124516138f, -0.273481987217745f }, { 0.485111864938318f, 0.874452101887844f }, { -0.307899752943979f, 0.951418804805243f }, { -0.991765219175154f, 0.128069317303008f }, { 0.937814305853532f, -0.347137332674633f },
		{ -0.398552509901734f, -0.917145515635893f }, { 0.701222178891205f, -0.712942813857514f }, { 0.873193936119955f, 0.487372906431349f }, { -0.514304676201594f, -0.857607544298191f }, { 0.0428414754286589f, 0.999081882521696f }, { -0.88038067821201f, 0.474267710719338f }, { 0.14177264550869f, 0.989899245875795f }, { -0.887664663265946f, -0.46049044027966f },
		{ 0.999983713358517f, -0.00570727760945115f }, { -0.623600504016441f, -0.781743187620104f }, { 0.888019464508127f, -0.459805861918592f }, { 0.600087177175954f, -0.79993460969569f }, { -0.560441030370991f, 0.828194331951567f }, { 0.958552181052623f, -0.284917033887514f }, { 0.6683586377581f, 0.743839183785136f }, { 0.709718808827001f, 0.704485068966819f },
		{ 0.695776987881928f, 0.718257880662615f }, { 0.154316110318401f, -0.988021527142096f }, { -0.725364342269412f, -0.688365143629501f }, { -0.999918869545931f, 0.0127379090116007f }, { 0.805508244111792f, 0.592584566680519f }, { -0.996506623245929f, 0.0835137702836865f }, { -0.73969279786535f, -0.67294469667732f }, { 0.695504007775371f, -0.718522216196824f },
		{ -0.999983227160896f, 0.00579183881678425f }, { -0.714924640549655f, 0.699201514825981f }, { -0.835103934916504f, -0.550092190352645f }, { 0.84959050330652f, 0.527442865807639f }, { -0.171610706906682f, 0.985164841676249f }, { 0.3561994988697f, 0.934409929851441f }, { -0.409182557485348f, -0.912452538299801f }, { 0.463529807851185f, 0.886081326534672f },
		{ -0.962925769084928f, -0.269766497608949f }, { 0.744285209959416f, 0.66786190656128f }, { -0.691027420259623f, 0.722828544296177f }, { 0.981612661017864f, 0.190883691627725f }, { 0.928340009081787f, 0.371732198683444f }, { -0.120562843572988f, 0.992705696946278f }, { 0.789437446513116f, -0.61383101749818f }, { 0.999774655712189f, -0.0212282310985648f },
		{ -0.902267580211854f, 0.431176545858708f }, { -0.912180652347305f, -0.4097883081339f }, { -0.770294485489921f, -0.637688329533965f }, { 0.20063205075057f, 0.979666667908846f }, { -0.982785937329741f, -0.184747940142514f }, { 0.857295252061123f, -0.514825068147866f }, { -0.6880675701609f, -0.725646621223357f }, { 0.703885918434739f, -0.710313039320893f },
		{ 0.80736694412922f, -0.590049673779628f }, { 0.501306939228223f, -0.865269526033149f }, { 0.994382489412099f, -0.105846420584718f }, { 0.496494368044017f, -0.868039942917705f }, { 0.077642279257408f, -0.996981281906393f }, { 0.951970808735996f, -0.30618879684687f }, { -0.761381916275718f, -0.648303615267041f }, { 0.925704511866975f, 0.378247480770363f },
		{ 0.307462004306155f, 0.951560358520699f }, { -0.722833511616144f, -0.6910222243059f }, { 0.365487416741135f, -0.930816280585966f }, { -0.452581511359919f, 0.891723037481466f }, { -0.696052038963733f, -0.717991336336609f }, { -0.731589205376628f, -0.681745725748533f }, { -0.584030912612065f, 0.811731416857521f }, { -0.622817071437575f, -0.782367493909303f },
		{ -0.250124556053565f, -0.968213667771224f }, { -0.972374793807189f, -0.233425063710878f }, { -0.970811073944879f, 0.239845489234194f }, { 0.972096169972212f, -0.234582685476477f }, { -0.56398693111627f, -0.825783713529185f }, { -0.697050386134155f, 0.717022146931478f }, { -0.0346220968223854f, -0.999400475490992f }, { -0.218763172462792f, -0.975777984161364f },
		{ -0.526228595935678f, 0.850343145335791f }, { 0.878475471267297f, 0.477787448957902f }, { -0.543258510315468f, 0.839565477476188f }, { -0.424638392098636f, 0.905363040970795f }, { -0.511241626148254f, -0.859437024855975f }, { 0.310536598007565f, -0.950561424263518f }, { 0.647207900842245f, 0.762313539881967f }, { -0.998374197564832f, 0.0569996634795082f },
		{ -0.384499699032222f, 0.923125116895933f }, { 0.793017652527103f, -0.609198656252953f }, { -0.108016962369769f, 0.994149051118799f }, { -0.931126682943364f, 0.364695901143526f }, { -0.801286360381044f, -0.598281011454734f }, { 0.875902620980454f, -0.482487925817394f }, { -0.731473336626206f, 0.681870044660216f }, { -0.315759562725525f, -0.948839237461956f },
		{ -0.0770741115938651f, -0.997025366438596f }, { -0.822418334736048f, 0.568883188967635f }, { -0.998852401248829f, -0.0478944727442276f }, { 0.996841343178929f, -0.0794187416749304f }, { -0.632437179039341f, 0.774611654036241f }, { 0.719989390873874f, 0.693985069745068f }, { 0.99256596306396f, -0.121707883750037f }, { 0.851153933233715f, -0.524916166583558f },
		{ 0.952866133004913f, 0.303391055524489f }, { 0.983070281370671f, 0.183228878416556f }, { 0.751614346163695f, 0.659602815822462f }, { 0.549915829679874f, 0.83522007894177f }, { 0.529779603383605f, 0.8481353499523f }, { -0.738299650910558f, -0.67447285005799f }, { -0.888225309084572f, -0.459408097775406f }, { 0.69138401830353f, 0.722487466489534f },
		{ 0.895582660271765f, -0.4448951546382f }, { -0.823764839572624f, -0.566931644101728f }, { 0.481527438369519f, 0.876431016165727f }, { -0.393245292146023f, 0.9194335974963f }, { 0.511430719572624f, 0.859324513252955f }, { 0.709782009015835f, 0.704421393540433f }, { -0.123429256704187f, -0.992353373848979f }, { -0.796333188996483f, -0.60485820826264f },
	};

	public static readonly float[,] LUT_Gradient3D =
	{
		{ 0.969192790963703f, -0.204588387787502f, -0.137145636191962f }, { 0.0105050866706296f, 0.869235070511719f, -0.494287401565657f }, { -0.00713466534361336f, -0.0561560433951495f, -0.998396512083569f }, { -0.99998707996014f, 0.00085789886042815f, 0.00501038145637507f }, { -0.729044421579981f, -0.0724223391156089f, 0.680624151907743f }, { -0.769477416524206f, 0.638612501748049f, 0.00886442724220208f }, { -0.148489274637499f, -0.733777362959066f, 0.662964340614538f }, { 0.00192647521945516f, -0.688227670545063f, 0.725492220626345f },
		{ 0.307853961011481f, -0.888296843306306f, 0.340814695782903f }, { -0.136873983993337f, 0.99058218544213f, 0.0035279442294635f }, { 0.981422965662359f, 0.0873011939299262f, -0.170843390299155f }, { 0.977985182924792f, 0.0274298762917452f, 0.206863684261352f }, { -4.10904184278805E-08f, -0.984715746607902f, -0.174169165992265f }, { -0.00576047279073815f, -0.00207046110763061f, 0.999981264896512f }, { 0.385796494451913f, -0.382885124111844f, 0.839380751865608f }, { 0.196898025871543f, -0.533803208609833f, 0.822365674068256f },
		{ -0.953574229510659f, -0.197141111727736f, -0.227665480211439f }, { 0.958192898763756f, -0.00565943080050262f, 0.286067019423289f }, { -0.000021414243574488f, 0.308183457620683f, 0.951326944846192f }, { -0.00156590253858546f, -0.936777289401244f, -0.349922645753741f }, { 0.010162930999189f, 0.907036729301754f, 0.420928837846829f }, { -0.0468274165634939f, 0.74026530347444f, -0.670682095727837f }, { -0.958782958606567f, 0.0676203469753538f, -0.275975953591197f }, { 0.000771226398681087f, -0.963152702156633f, 0.268954043543163f },
		{ -0.939601847652347f, 0.341933173840782f, -0.0151681414637957f }, { 0.0836248033533964f, 0.431468628956066f, 0.898243683245743f }, { -0.97637082132863f, 0.118948680332271f, 0.180419596234078f }, { 0.103518422502263f, 0.000465187240855595f, -0.994627427634827f }, { -0.141353740004181f, 0.0778654829014707f, -0.98689213532146f }, { 0.0700630230682292f, 0.912644877864809f, -0.402703985212052f }, { 0.991874945122624f, -0.0502217417385342f, 0.116884001876814f }, { -0.707119760481927f, 0.700142261026601f, -0.0989063125414175f },
		{ 0.0976913606831578f, 0.99518571412564f, -0.00786081726752686f }, { 0.865756754070504f, 0.268594575188625f, 0.422282129577546f }, { 0.0124864728918991f, -0.922679395826772f, -0.385365826859963f }, { -0.0174011080646746f, -0.984212730893662f, 0.176132057800279f }, { 0.983085383617433f, 0.183144250425653f, 0.00114544916535278f }, { 0.84177325324929f, -0.000849099388075524f, 0.539830593005191f }, { -0.773202768542597f, 0.634158480426922f, -0.000707404184135718f }, { -0.399463762408861f, 0.520122522942901f, -0.754918050949683f },
		{ -0.0543404007696243f, 0.853240000077495f, -0.51867969221086f }, { 0.0787561128671418f, -0.0445112338899157f, -0.995899706167069f }, { -0.149110911377271f, -0.855893524471146f, -0.495189065788614f }, { 0.128579845943545f, 0.95447163354276f, 0.26916746456314f }, { -6.48712081276198E-06f, -0.417292224145094f, 0.908772358528778f }, { -0.18395289837094f, 0.967255425062472f, 0.174866445804071f }, { -0.0956465003848313f, -0.995413983868259f, -0.00165761384418054f }, { -0.493402767926647f, 0.252656257103973f, 0.83229713705415f },
		{ 0.941743815026262f, -0.00313821941824732f, 0.336316426061328f }, { -0.406002839825049f, -0.660621950516609f, -0.631458892208849f }, { -0.0151930656231186f, 0.000118750826499392f, 0.999884571665756f }, { 0.681786958463344f, -0.719431781259153f, 0.132606392695014f }, { 0.973323591185432f, -0.228922756390528f, 0.0153479134887209f }, { -0.810634856852843f, -0.585551171144037f, 0.000977152504195713f }, { -0.181398855060402f, -0.831693356111209f, 0.524767202465292f }, { -0.733900500867695f, 0.679256981569713f, 8.84021970721802E-05f },
		{ 0.271727663466327f, -0.889119678670303f, -0.368280156821335f }, { 0.298233653375395f, -0.0312311598898426f, -0.953981814630813f }, { -0.752318728102205f, -0.00392703305301813f, 0.658787605953604f }, { 0.00665991896444102f, -0.893539727653096f, 0.448934739784101f }, { -0.17274029679022f, 0.981849574845414f, 0.0783083791219516f }, { 0.740984319707759f, -1.24163939998686E-09f, 0.671522328703395f }, { -0.91345982474963f, 0.00101800775270491f, 0.40692764986984f }, { 0.166118424599226f, -0.966950978532905f, -0.193417874362556f },
		{ -0.371630916510155f, 0.92837704130171f, -0.00255559732836468f }, { 0.114876798169617f, 0.991537470331245f, 0.0604712011738797f }, { 0.42509283827761f, -0.861877415693766f, -0.276520160498508f }, { 0.0914177278602429f, 0.937282941514681f, 0.336368081985282f }, { -0.138897098096673f, 0.574329772420649f, -0.806754552916541f }, { 4.20730659972853E-05f, -0.973522779481066f, 0.228590017413966f }, { -0.19883302527571f, -0.769560727972852f, -0.606829229702725f }, { 0.0747279815185906f, 0.375429090417211f, 0.92383371168553f },
		{ 0.0360592551928224f, 0.999349653582228f, 1.40580077597545E-07f }, { -0.630789398266975f, 0.775912761477526f, 0.00800759703705387f }, { 0.999468273136104f, 0.0122075383077114f, -0.0302348640281232f }, { 0.0234858830298487f, 0.722121551769761f, -0.691367397096465f }, { 0.044647769484317f, -0.998966611124733f, -0.00850214902496602f }, { -0.155624581702642f, 0.0567240593672596f, -0.98618627584183f }, { -0.564856042306962f, 0.825189463979779f, 2.46592673497201E-06f }, { -0.00280893077197093f, -0.849678682544325f, 0.527293320968186f },
		{ 0.85760478967376f, 0.0912484314080345f, -0.506149926893406f }, { -0.983676972673489f, -0.138789081908023f, -0.11453036355067f }, { -0.995791780173427f, 0.0916344946719056f, 0.00136011957614869f }, { 0.0705163298667096f, 0.9883873876068f, -0.134602448870495f }, { 0.151288867759186f, -0.946777269461834f, -0.28412053871999f }, { -0.479182164834798f, 2.28582795501955E-06f, 0.877715473772117f }, { -0.920617168247744f, -0.0874211800038508f, -0.380554288918466f }, { 0.647008224881357f, -0.0116892424293656f, -0.76239341454875f },
		{ 0.00348600295131339f, 0.00264876419739902f, 0.999990415869897f }, { 0.293662611616922f, 0.774229458412962f, -0.560652313170918f }, { -0.0230822002633608f, -0.133701316157593f, -0.99075282996756f }, { 0.0891587773276397f, -0.70303221860981f, -0.705546888606285f }, { -0.716380181025389f, -0.675240051032385f, 0.175642562369752f }, { -0.110229513550145f, -0.0380431704478986f, 0.993177814655951f }, { 0.901899360101853f, -0.423583957873496f, -0.0845823556073773f }, { -0.188144760211676f, 0.981876973408649f, 0.0227850454193412f },
		{ -0.992971049488398f, -0.00105311622549315f, -0.118352802350111f }, { 0.974825103742426f, -0.22297088847484f, 2.51166485428216E-06f }, { 0.917736330268161f, 0.253456586759036f, -0.305810050087285f }, { 0.754361752313554f, 0.655909079393725f, -0.0268631013715986f }, { -0.00493426945610691f, 0.999852337890823f, -0.0164607229243032f }, { 0.172163344055272f, 0.977404359568319f, -0.122639719750783f }, { 0.20654798485596f, 0.00802290795582379f, 0.978403578744413f }, { -0.0189935909416278f, -0.956252765802595f, -0.291924461801387f },
		{ -0.298030174309119f, -0.101625749247146f, -0.949131298762838f }, { -0.525057139557522f, -0.851050276233871f, 0.00533174661105069f }, { 0.00362214069523366f, 0.401488407244411f, -0.915856942401558f }, { 0.7517944143271f, 0.19472711592481f, 0.629989292694866f }, { 0.501284099317453f, -0.0225214021165674f, 0.864989617404853f }, { -0.985033512468648f, 0.1680612553394f, -0.0382673982316817f }, { 0.00137633273570574f, -0.0442369494900767f, -0.999020118920542f }, { -0.724166817672979f, -0.688818418185576f, 0.033340770082758f },
		{ -0.0128146550963728f, -0.0397993929245446f, 0.99912551410601f }, { 0.802033957950016f, 0.595775400910827f, -0.0423462154693413f }, { -0.902335114745471f, -0.411652900762455f, -0.127801525777801f }, { 7.40750655087705E-05f, -0.890177016591854f, 0.455614830360591f }, { -0.0563694832642116f, 0.998393830705426f, -0.00567804243293261f }, { 0.804825783463094f, 0.0873894235068948f, -0.587042202002675f }, { 0.902405167679558f, 0.0887442050097385f, -0.421650778989461f }, { 0.0138828478418606f, -0.26021714739708f, 0.965450310858268f },
		{ -0.0235002961872274f, -0.1428517727679f, -0.989465061079056f }, { 0.543378228613975f, 0.00830368325812741f, 0.839446930730399f }, { -0.956960500295924f, 0.0113747804839107f, 0.289995198653906f }, { -0.00858337504492301f, -0.949962410388146f, -0.312246288244364f }, { -0.731827611403257f, 0.00140870300297461f, -0.681488343806152f }, { 0.844453636307317f, 0.498643416559842f, -0.195583228444764f }, { -0.997648624781726f, 0.000128342870118087f, -0.0685361583343983f }, { 0.00700544496566235f, -0.020878882722484f, 0.999757468587804f },
	};

	/// <summary>
	/// NoiseBasic Constructor.
	/// </summary>
	public NoiseGradient( )
	{
		noiseType = NoiseType.Gradient;
	}

	/// <summary>
	/// Get a 2D gradient LUT index.
	/// </summary>
	/// <param name="xi">xi</param>
	/// <param name="yi">yi</param>
	/// <param name="x">x</param>
	/// <param name="y">y</param>
	/// <returns>2D look-up table result.</returns>
	float GetGradientCoord( int xi, int yi, float x, float y )
	{
		float xs = x - ( float )xi;
		float ys = y - ( float )yi;

		int lutPos = GetLUTIndex( xi, yi );
		return ( xs*LUT_Gradient2D[lutPos, 0] + ys*LUT_Gradient2D[lutPos, 1] );
	}

	/// <summary>
	/// Get a 3D gradient LUT index.
	/// </summary>
	/// <param name="xi">xi</param>
	/// <param name="yi">yi</param>
	/// <param name="zi">zi</param>
	/// <param name="x">x</param>
	/// <param name="y">y</param>
	/// <param name="z">z</param>
	/// <returns>3D look-up table result.</returns>
	float GetGradientCoord( int xi, int yi, int zi, float x, float y, float z )
	{
		float xs = x - ( float )xi;
		float ys = y - ( float )yi;
		float zs = z - ( float )zi;

		int lutPos = GetLUTIndex( xi, yi, zi );
		return( xs*LUT_Gradient3D[lutPos, 0] + ys*LUT_Gradient3D[lutPos, 1] + zs*LUT_Gradient3D[lutPos, 2] );
	}

	/// <summary>
	/// Get a 2D noise value.
	/// </summary>
	/// <param name="x">x</param>
	/// <param name="y">y</param>
	/// <returns>Result of 2D noise.</returns>
	float GetGradient( float x, float y )
	{
		int x0 = FastFloor( x );
		int y0 = FastFloor( y );
		int x1 = x0 + 1;
		int y1 = y0 + 1;

		float xs = 0.0f;
		float ys = 0.0f;
		switch( interpolationType )
		{
			case InterpolationType.Linear:
				xs = x - ( float )x0;
				ys = y - ( float )y0;
			break;

			case InterpolationType.Hermite:
				xs = InterpHermite( x - ( float )x0 );
				ys = InterpHermite( y - ( float )y0 );
			break;

			case InterpolationType.Quintic:
				xs = InterpQuintic( x - ( float )x0 );
				ys = InterpQuintic( y - ( float )y0 );
			break;
		}

		float xf0 = Lerp( GetGradientCoord( x0, y0, x, y ), GetGradientCoord( x1, y0, x, y ), xs );
		float xf1 = Lerp( GetGradientCoord( x0, y1, x, y ), GetGradientCoord( x1, y1, x, y ), xs );

		return( Lerp( xf0, xf1, ys )*1.4f );
	}

	/// <summary>
	/// Get a 3D noise value.
	/// </summary>
	/// <param name="x">x</param>
	/// <param name="y">y</param>
	/// <param name="z">z</param>
	/// <returns>Result of 3D noise.</returns>
	private float GetGradient( float x, float y, float z )
	{
		int x0 = FastFloor( x );
		int y0 = FastFloor( y );
		int z0 = FastFloor( z );
		int x1 = x0 + 1;
		int y1 = y0 + 1;
		int z1 = z0 + 1;

		float xs = 0.0f;
		float ys = 0.0f;
		float zs = 0.0f;
		switch( interpolationType )
		{
			case InterpolationType.Linear:
				xs = x - ( float )x0;
				ys = y - ( float )y0;
				zs = z - ( float )z0;
			break;

			case InterpolationType.Hermite:
				xs = InterpHermite( x - ( float )x0 );
				ys = InterpHermite( y - ( float )y0 );
				zs = InterpHermite( z - ( float )z0 );
			break;

			case InterpolationType.Quintic:
				xs = InterpQuintic( x - ( float )x0 );
				ys = InterpQuintic( y - ( float )y0 );
				zs = InterpQuintic( z - ( float )z0 );
			break;
		}

		float xf00 = Lerp( GetGradientCoord( x0, y0, z0, x, y, z ), GetGradientCoord( x1, y0, z0, x, y, z ), xs );
		float xf10 = Lerp( GetGradientCoord( x0, y1, z0, x, y, z ), GetGradientCoord( x1, y1, z0, x, y, z ), xs );
		float xf01 = Lerp( GetGradientCoord( x0, y0, z1, x, y, z ), GetGradientCoord( x1, y0, z1, x, y, z ), xs );
		float xf11 = Lerp( GetGradientCoord( x0, y1, z1, x, y, z ), GetGradientCoord( x1, y1, z1, x, y, z ), xs );

		float yf0 = Lerp( xf00, xf10, ys );
		float yf1 = Lerp( xf01, xf11, ys );

		return( Lerp( yf0, yf1, zs )*1.4f );
	}

	/// <summary>
	/// 2D noise gradient type method.
	/// </summary>
	/// <param name="x">x</param>
	/// <param name="y">y</param>
	/// <returns>Noise value.</returns>
	public override float GetNoise( float x, float y )
	{
		x*= frequency;
		y*= frequency;

		float sum = 0.0f;
		float max = 1.0f;
		float amp = 1.0f;
		uint i = 0;

		int seedPrev = seed;

		switch( fractalType )
		{
			case FractalType.FBM:
				sum = GetGradient( x, y );

				while( ++i < octaves )
				{
					x*= lacunarity;
					y*= lacunarity;

					amp*= gain;
					max+= amp;

					++seed;
					sum+= GetGradient( x, y )*amp;
				}
			break;

			case FractalType.Billow:
				sum = FastAbs( GetGradient( x, y ) )*2.0f - 1.0f;

				while( ++i < octaves )
				{
					x*= lacunarity;
					y*= lacunarity;
					amp*= gain;
					max+= amp;

					++seed;
					sum+= ( FastAbs( GetGradient( x, y ) )*2.0f - 1.0f )*amp;
				}
			break;

			case FractalType.RigidMulti:
				sum = 1.0f - FastAbs( GetGradient( x, y ) );

				while( ++i < octaves )
				{
					x*= lacunarity;
					y*= lacunarity;

					amp*= gain;

					++seed;
					sum -= ( 1.0f - FastAbs( GetGradient( x, y ) ) )*amp;
				}
			break;
		}

		seed = seedPrev;
		return( sum/max );
	}

	/// <summary>
	/// 3D noise gradient type method.
	/// </summary>
	/// <param name="x">x</param>
	/// <param name="y">y</param>
	/// <param name="z">z</param>
	/// <returns>Noise value.</returns>
	public override float GetNoise( float x, float y, float z )
	{
		x*= frequency;
		y*= frequency;
		z*= frequency;

		x*= frequency;
		y*= frequency;

		float sum = 0.0f;
		float max = 1.0f;
		float amp = 1.0f;
		uint i = 0;

		int seedPrev = seed;

		switch( fractalType )
		{
			case FractalType.FBM:
				sum = GetGradient( x, y, z );

				while( ++i < octaves )
				{
					x*= lacunarity;
					y*= lacunarity;
					z*= lacunarity;

					amp*= gain;
					max+= amp;

					++seed;
					sum+= GetGradient( x, y, z )*amp;
				}
			break;

			case FractalType.Billow:
				sum = FastAbs( GetGradient( x, y ) )*2.0f - 1.0f;

				while( ++i < octaves )
				{
					x*= lacunarity;
					y*= lacunarity;
					z*= lacunarity;

					amp*= gain;
					max+= amp;

					++seed;
					sum+= ( FastAbs( GetGradient( x, y, z ) )*2.0f - 1.0f )*amp;
				}
			break;

			case FractalType.RigidMulti:
				sum = 1.0f - FastAbs( GetGradient( x, y, z ) );

				while( ++i < octaves )
				{
					x*= lacunarity;
					y*= lacunarity;
					z*= lacunarity;

					amp*= gain;

					++seed;
					sum -= ( 1.0f - FastAbs( GetGradient( x, y, z ) ) )*amp;
				}
			break;
		}

		seed = seedPrev;
		return( sum/max );
	}

	/// <summary>
	/// 4D noise gradient type method (not implemented, just returns 3D noise value).
	/// </summary>
	/// <param name="x">x</param>
	/// <param name="y">y</param>
	/// <param name="z">z</param>
	/// <param name="w">w</param>
	/// <returns>Noise value.</returns>
	public override float GetNoise( float x, float y, float z, float w )
	{
		// No implementation; Return 3D noise value.
		// Toss in a console print here eventually.

		// Which means it'll probably never get done. 

		return( GetNoise( x, y, z ) );
	}
}
